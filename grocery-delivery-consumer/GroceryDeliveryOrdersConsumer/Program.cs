using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GroceryDeliveryOrdersConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var config = new ConsumerConfig
                    {
                        BootstrapServers = "localhost:9092",
                        EnableAutoCommit = false,
                        GroupId = "order-consumers",
                        AutoOffsetReset = AutoOffsetReset.Earliest
                    };
                    var consumer = new ConsumerBuilder<string, string>(config).Build();
                    consumer.Subscribe("orders");

                    services.AddHostedService(sp => new OrdersConsumerService(sp.GetRequiredService<ILogger<OrdersConsumerService>>(), consumer));
                });
    }
}
