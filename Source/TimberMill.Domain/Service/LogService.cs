using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using NLog.LogReceiverService;
using TimberMill.Domain.Repositories;

namespace TimberMill.Domain.Service
{
    public class LogService
    {
        private ISourceRepository _sourceRepository;
        private IBatchRepository _batchRepository;

        public LogService(ISourceRepository sourceRepository, IBatchRepository batchRepository)
        {
            _sourceRepository = sourceRepository;
            _batchRepository = batchRepository;
        }

        public void LogEvents(string clientName, List<NLogEvent> events)
        {
            var source = _sourceRepository.GetOrCreate(clientName);
            var batch = _batchRepository.Create(source);

            foreach (var nlogEvent in events)
            {
                //nlogEvent.
            }
            
        }
    }
}
