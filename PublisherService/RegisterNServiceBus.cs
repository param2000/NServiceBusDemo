using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace PublisherService
{
    public class RegisterNServiceBus : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Configure.With()
                     .DefiningEventsAs(m => m.Namespace != null && m.Namespace.StartsWith("MyMessages"))
                     .CastleWindsorBuilder(container) //contianer object NServiceBus will be using 
                     .Log4Net()                         //for logging we will be using Log4net 
                     .XmlSerializer()                   // for serialization of messages 
                     .MsmqTransport()                  
                     .DisableRavenInstall()             //by default NServiceBus uses raven, we are not using ravendb at all
                                                           
                     .MsmqSubscriptionStorage()         // we will be using MSMQ for our subscription storage 
                                                        //storage for publisher to keep track of all the publishers subscribed to the message being published 
                     .IsTransactional(true)             //
                     .UnicastBus()
                     .LoadMessageHandlers()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());
        }
    }
}