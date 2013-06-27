using System;
using NServiceBus;

namespace MyCommands
{
    public interface IMyCommand : ICommand
    {
        Guid Id { get; set; }
        string SomeInfo { get; set; }
    }
}
