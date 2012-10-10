using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.LogReceiverService;
using TimberMill.Domain.Objects;
using TimberMill.Domain.Repositories;

namespace TimberMill.Domain.Service
{
    public class LogService
    {
        #region Fields

        private ISourceRepository _sourceRepository;
        private IBatchRepository _batchRepository;
        private ILogEventRepository _eventRepository;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        #endregion

        #region Ctor

        public LogService(ISourceRepository sourceRepository, IBatchRepository batchRepository, ILogEventRepository eventRepository)
        {
            _sourceRepository = sourceRepository;
            _batchRepository = batchRepository;
            _eventRepository = eventRepository;
        }

        #endregion

        #region Methods

        public void LogEvents(NLogEvents events)
        {
            Source source = ParseAndCreateSource(events.ClientName);

            if (source == null)
            {
                Log.Error("Ignoring received events");
                return;
            }

            var batch = _batchRepository.Create(source);
           
            var timberMillEvents = ExtractLogEvents(events, batch);
            timberMillEvents.ForEach(_eventRepository.Save);

            Log.Info("Received {0} events from {1}", timberMillEvents.Count, source);
        }

        private static List<LogEvent> ExtractLogEvents(NLogEvents events, Batch batch)
        {
            var logEventInfoList = events.ToEventInfo().ToList();
            var timberMillEvents = logEventInfoList.ConvertAll(ei => TimberMillEventFactory(batch, ei));
            return timberMillEvents;
        }

        private static LogEvent TimberMillEventFactory(Batch batch, LogEventInfo eventInfo)
        {
            LogEvent timberMillEvent = new LogEvent();
            
            timberMillEvent.Batch = batch;
            timberMillEvent.TimeStamp = eventInfo.TimeStamp;
            timberMillEvent.Level = eventInfo.Level.Name;
            timberMillEvent.Message = eventInfo.Message;
            timberMillEvent.Sequence = eventInfo.SequenceID;
            
            foreach(KeyValuePair<object, object> property in eventInfo.Properties)
            {
                switch(property.Key.ToString())
                {
                    case "exception":
                        timberMillEvent.Exception = property.Value.ToString();
                        break;
                }
            }
            return timberMillEvent;
        }

        private Source ParseAndCreateSource(string clientName)
        {
            if (string.IsNullOrEmpty(clientName))
            {
                Log.Error("ClientName unexpectedly null");
                return null;
            }
            string[] categorySourceSplit = clientName.Split(new []{"|"}, StringSplitOptions.None);
            string sourceCategory = null;
            string sourceName;
            switch(categorySourceSplit.Length)
            {
                case 2:
                    sourceName = categorySourceSplit[0];
                    sourceCategory = categorySourceSplit[1];
                    break;
                case 1:
                    sourceName = categorySourceSplit[0];
                    break;
                default:
                    Log.Error("clientName had too many pipe separators");
                    return null;
            }
            return _sourceRepository.GetOrCreate(sourceName, sourceCategory);
        }

        #endregion
    }
}
