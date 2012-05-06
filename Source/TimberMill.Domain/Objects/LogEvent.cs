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

        public string LoggerName { get; set; }

        public int Level { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
        

    }
}
