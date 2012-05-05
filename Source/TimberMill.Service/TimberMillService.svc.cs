using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NLog;
using NLog.LogReceiverService;
using TimberMill.Domain.Service;

namespace TimberMill.Service
{
    
    public class TimberMillService : ILogReceiverServer
    {
        #region Fields
        private readonly LogService _logService;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        #endregion
        
        #region Ctor
        public TimberMillService(LogService logService)
        {
            _logService = logService;
        }
        #endregion

        #region ILogReceiverServer Members

        public void ProcessLogMessages(NLogEvents nevents)
        {

            if (nevents == null)
            {
                Log.Info("Received was null");
                return;
            }
            var events = nevents.ToEventInfo("Client");
            Log.Info("Received {0} events", events.Count);
            
            foreach (var ev in events)
            {
                var logger = LogManager.GetLogger(ev.LoggerName);
                logger.Log(ev);
            }

            //Log.Info("in: {0} {1}", nevents.Events.Length, events.Count);
            _logService.LogEvents(nevents.ClientName, nevents.Events.ToList());
        }
        #endregion
    }

}
