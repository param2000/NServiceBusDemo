using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace ConsumerService
{
    public class RegisterNServiceBus : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Configure.With()
                     .DefiningEventsAs(m => m.Namespace != null && m.Namespace.StartsWith("MyMessages"))
                     .CastleWindsorBuilder(container) 
                     .Log4Net()
                     .XmlSerializer()
                     .MsmqTransport()                  
                     .DisableRavenInstall()
                     .RunTimeoutManager()
                     .UseInMemoryTimeoutPersister()
                     .IsTransactional(true)          
                     .UnicastBus()
                     .LoadMessageHandlers()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
        }
    }
}