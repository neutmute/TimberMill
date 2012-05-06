using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace TimberMill.Domain.Objects
{
    public class LogEvent
    {
        public int Id { get; set; }

        public Batch Batch { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionStackTrace { get; set; }

        public LogEvent()
        {
            
        }

        public LogEvent(Batch batch, LogEventInfo eventInfo)
        {
            Batch = batch;

            Level = eventInfo.Level.Name;
            Message = eventInfo.FormattedMessage;
            TimeStamp = eventInfo.TimeStamp;

            if (eventInfo.Exception == null)
            {
                ExceptionMessage = null;
                ExceptionStackTrace = null;
            }
            else
            {
                ExceptionMessage = eventInfo.Exception.Message;
                ExceptionStackTrace = eventInfo.Exception.StackTrace;
            }
        }
    }
}
