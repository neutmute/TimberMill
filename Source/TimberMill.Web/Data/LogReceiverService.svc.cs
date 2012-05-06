using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NLog;
using NLog.LogReceiverService;
using TimberMill.Domain.Service;

namespace TimberMill.Web.Data
{
    public class LogReceiverService : ILogReceiverServer
    {
        #region Fields
        private readonly LogService _logService;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        #endregion

        #region Ctor
        public LogReceiverService(LogService logService)
        {
            _logService = logService;
        }
        #endregion

        #region ILogReceiverServer Members

        public void ProcessLogMessages(NLogEvents nevents)
        {
            var events = nevents.ToEventInfo("Client");
            Log.Info("Received {0} events from {1}", events.Count, nevents.ClientName);

            _logService.LogEvents(nevents.ClientName, events);
        }
        #endregion
    }
}
