using System;
using System.ServiceProcess;
using Castle.Windsor;
using MyMessages;
using NServiceBus;
using log4net;

namespace PublisherService
{
    public partial class PublisherService : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(PublisherService));
        private readonly IWindsorContainer _container;
        private readonly IBus _bus;
        public PublisherService()
        {
            InitializeComponent();
            _container = new WindsorContainer();
            
            var registrar = new RegisterComponents(_container);
            registrar.RegisterEverything();
            _bus = _container.Resolve<IBus>();
        }

        protected override void OnStart(string[] args)
        {
                _log.Info("Starting to publish Messages");
             
                _log.InfoFormat("Press any key to keep publish a message");
                while (Console.ReadLine() != null)
                {       
                    _bus.Publish<IMyMessage>(m => { m.Id = Guid.NewGuid();m.SomeInfo = "this is demo message for publishing ";});
                }
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
