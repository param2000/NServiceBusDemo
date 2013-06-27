using System;
using System.ServiceProcess;

namespace PublisherService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            if (args.Length > 0 && Array.IndexOf(args, @"/console") != -1)
            {
                var service = new PublisherService();
                service.RunConsole(args);
            }
            else
            {
                var servicesToRun = new ServiceBase[] { new PublisherService() };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
