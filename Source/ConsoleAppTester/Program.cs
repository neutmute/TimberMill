using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NLog;

namespace ConsoleAppTester
{
    class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
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
