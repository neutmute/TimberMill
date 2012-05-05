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

            TimberMill.Service.LogReceiverServerClient client = new TimberMill.Service.LogReceiverServerClient();
            client.ProcessLogMessages(null);

            for (int i = 0; i < 10; i++)
            {
                Log.Info("Iteration i={0}", i);

                if (i % 2 == 0)
                {
                    Log.Trace("Even number iteration {0}", i);
                }
                //Thread.Sleep(20);
            }
        }
    }
}
