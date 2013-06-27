using System;
using NServiceBus;

namespace MyMessages
{
    public interface IMyMessage:IEvent
    {
        Guid Id { get; set; }
        string SomeInfo { get; set; }
    }
}