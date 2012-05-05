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
            Log.Info("Received wasnt NULL!");
            //Log.Info("in: {0} {1}", nevents.Events.Length, events.Count);
            _logService.LogEvents(nevents.ClientName, nevents.Events.ToList());
        }
        #endregion
    }

}
