using System;
using MyCommands;
using MyMessages;
using NServiceBus;
using log4net;

namespace ConsumerService
{
    public class HandleMyMessage :IHandleMessages<IMyMessage>
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HandleMyMessage));
        public virtual IBus Bus { get; set; }

        public void Handle(IMyMessage message)
        {
            _log.InfoFormat("Message received with id ={0} and info ={1}",message.Id,message.SomeInfo);
            
            Bus.Send<IMyCommand>("PublisherService",m =>
            {
                m.Id = Guid.NewGuid();
                m.SomeInfo = "Consumer said >>I Received the message";
            });
            
        }
    }
}