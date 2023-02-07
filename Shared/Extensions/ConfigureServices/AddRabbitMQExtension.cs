using MassTransit;

namespace Shared.Extensions;

public static partial class RabbitMQExtension
{
    public static void CreateQueue<T>(this IRabbitMqBusFactoryConfigurator cfg, string serviceName, IRegistrationContext ctx) where T : class, IConsumer
    {
        cfg.ReceiveEndpoint(serviceName, e =>
        {
            e.ConfigureConsumer<T>(ctx);
        });
    }
}