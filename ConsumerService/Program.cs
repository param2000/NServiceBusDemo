using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace ConsumerService
{
    static class Program
    {  /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            if (args.Length > 0 && Array.IndexOf(args, @"/console") != -1)
            {
                var service = new ConsumerService();
                service.RunConsole(args);
            }
            else
            {
                var servicesToRun = new ServiceBase[] { new ConsumerService() };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
