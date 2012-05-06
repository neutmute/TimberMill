TimberMill (Where all the logs are sent!)
==============================================
Implementation of ILogReceiverServer to receive logs from the LogReceiverService target (http://nlog-project.org/wiki/LogReceiverService_target).
Uses WCF BasicHttp binding.
Saves logs to a centralised database using Entity Framework Code First.

See the 'ConsoleAppTester' project in the solution for an example client binding.
