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

        public void LogEvents(string clientName, IList<LogEventInfo> events)
        {
            Source source = GetSource(clientName);
            var batch = _batchRepository.Create(source);

            foreach (var nlogEvent in events)
            {
                var logEvent = new LogEvent(batch, nlogEvent);
                _eventRepository.Save(logEvent);
            }
            Log.Info("{0} events saved", events.Count);
        }

        private Source GetSource(string clientName)
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
