using System;
using MyCommands;
using NServiceBus;
using log4net;

namespace PublisherService
{
    public class HandleMyCommand : IHandleMessages<IMyCommand>
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HandleMyCommand));
        public virtual IBus Bus { get; set; }

        public void Handle(IMyCommand message)
        {
            _log.InfoFormat("Command received with id ={0} and someInfo ={1}",message.Id,message.SomeInfo);
        }
    }
}
