using System;
using Castle.Windsor;
using log4net;

namespace ConsumerService
{
    public class RegisterComponents
    {
        private readonly IWindsorContainer _container;
        private readonly ILog _log = LogManager.GetLogger(typeof(RegisterComponents));

        public RegisterComponents(IWindsorContainer container)
        {
            _container = container;
        }

        public void RegisterEverything()
        {
            try
            {
                _container.Install(new RegisterNServiceBus());
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Publisher Service had an error while registering NServiceBus {0}",ex);
            }
        }
    }
}