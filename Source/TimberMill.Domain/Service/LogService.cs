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
        private ISourceRepository _sourceRepository;
        private IBatchRepository _batchRepository;
        private ILogEventRepository _eventRepository;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public LogService(ISourceRepository sourceRepository, IBatchRepository batchRepository, ILogEventRepository eventRepository)
        {
            _sourceRepository = sourceRepository;
            _batchRepository = batchRepository;
            _eventRepository = eventRepository;
        }

        public void LogEvents(NLogEvents events)
        {
            Source source = ParseClientName(events.ClientName);
            var batch = _batchRepository.Create(source);
           
            var timberMillEvents = ExtractLogEvents(events, batch);
            timberMillEvents.ForEach(_eventRepository.Save);

            Log.Info("Received {0} events from {1}", timberMillEvents.Count, source);
        }

        private List<LogEvent> ExtractLogEvents(NLogEvents events, Batch batch)
        {
            var baseTimeUtc = new DateTime(events.BaseTimeUtc, DateTimeKind.Utc);
            List<LogEvent> timberMillEvents = new List<LogEvent>();
            for (int j = 0; j < events.Events.Length; ++j)
            {
                var ev = events.Events[j];

                LogEvent timbermillEvent = new LogEvent();

                timbermillEvent.Batch = batch;
                timbermillEvent.TimeStamp = baseTimeUtc.AddTicks(ev.TimeDelta);
                timbermillEvent.Level = ev.LevelOrdinal;
                timbermillEvent.Message = events.Strings[ev.MessageOrdinal];
                timbermillEvent.LoggerName = events.Strings[ev.LoggerOrdinal];

                //for (int i = 0; i < events.LayoutNames.Count; ++i)
                //{
                //    string layoutName = events.LayoutNames[i];
                //    switch (layoutName)
                //    {
                //        case "exception":
                //            timbermillEvent.Exception = ev.Values[i];
                //            break;
                //    }
                //}    
              
            }
            return timberMillEvents;
        }

        private Source ParseClientName(string clientName)
        {
            string[] categorySourceSplit = clientName.Split(new []{"|"}, StringSplitOptions.None);
            string sourceCategory = null;
            string sourceName;
            switch(categorySourceSplit.Length)
            {
                case 2:
                    sourceCategory = categorySourceSplit[0];
                    sourceName = categorySourceSplit[1];
                    break;
                case 1:
                    sourceName = categorySourceSplit[0];
                    break;
                default:
                    throw new ArgumentException("clientName had too many pipe separators");
            }
            return _sourceRepository.GetOrCreate(sourceName, sourceCategory);
        }
    }
}
