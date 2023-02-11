using MassTransit;
using Shared.Messages;

namespace Shared.EventBus;

public class ExampleConsumer : IConsumer<HelloWord>
{
    public Task Consume(ConsumeContext<HelloWord> context)
    {
        Console.WriteLine("Hello World");
        return Task.CompletedTask;
    }
}