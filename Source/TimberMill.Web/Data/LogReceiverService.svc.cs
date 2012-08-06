using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Kraken.Framework.Core.Web;
using NLog;
using NLog.LogReceiverService;
using TimberMill.Domain.Service;

namespace TimberMill.Web.Data
{
    [KrakenWcfErrorHandler]
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
            //Log.Info("ChannelAddress={0}", OperationContext.Current.Channel.LocalAddress);
            _logService.LogEvents(nevents);
        }
        #endregion
    }
}
