using System;
using System.ServiceProcess;
using Castle.Windsor;
using MyMessages;
using NServiceBus;
using log4net;

namespace ConsumerService
{
    public partial class ConsumerService : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(ConsumerService));
        private readonly IWindsorContainer _container;
        private readonly IBus _bus;
        public ConsumerService()
        {
            InitializeComponent();
            _container = new WindsorContainer();
            
            var registrar = new RegisterComponents(_container);
            registrar.RegisterEverything();
            _bus = _container.Resolve<IBus>();
        }

        protected override void OnStart(string[] args)
        {
                _log.Info("Starting service to consume Messages");
                while (Console.ReadLine() != null)
                {}
        }

        protected override void OnStop()
        {}

        public void RunConsole(string[] args)
        {
            OnStart(args);
            OnStop();
        }
    }
}
