using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using NLog;
using NLog.LogReceiverService;

namespace ConsoleAppTester
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
         //   TestProxyConfig();

            var c = new ServiceReference1.LogReceiverServerClient();
            NLogEvents v = new NLogEvents();
            
            c.ProcessLogMessages(v);

            TestExceptionLog();
            TestExceptionLog2();

            for (int i = 0; i <= 10; i++)
            {
                Log.Info("Iteration i={0}", i);

                if (i % 2 == 0)
                {
                    Log.Trace("Even number iteration {0}", i);
                }

            }

            Thread.Sleep(10000);
        }

        private static void TestProxyConfig()
        {
            WebClient c = new WebClient();
            
            var s = c.OpenRead("https://www.snowmute.net/TimberMillDev/Data/LogReceiverService.svc");
            StreamReader sr = new StreamReader(s);
            var result = sr.ReadToEnd();
        }

        private static void TestExceptionLog()
        {
            var exception = new ApplicationException("Testing the Exception logging");
            Log.InfoException("the log message", exception);
        }

        private static void TestExceptionLog2()
        {
            try
            {
                int i = 0;
                int j = 4;
                int k = j / i;
            }
            catch (Exception e)
            {
                Log.WarnException("Phew that was close", e);
            }
        }
    }
}
