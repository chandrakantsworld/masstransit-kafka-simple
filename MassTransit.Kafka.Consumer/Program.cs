using MassTransit;
using MassTransit.Kafka.Consumer;
using MassTransit.Kafka.Shared;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddMassTransit(x =>
{
    const string topicName = "topicName-medium";
    const string consumerGroup = "consumer-group-medium";
    const string kafkaBrokerServers = "localhost:9092";

    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

    x.AddRider(r =>
    {
        r.AddConsumer<KafkaMessageConsumer>();
        r.UsingKafka((context, k) =>
        {
            k.Host(kafkaBrokerServers);
            k.TopicEndpoint<IMessage>(topicName, consumerGroup, e =>
            {
                e.ConfigureConsumer<KafkaMessageConsumer>(context);
                e.CreateIfMissing();
            });
        });
    });
});

var provider = services.BuildServiceProvider();

var busControl =  provider.GetRequiredService<IBusControl>();

await busControl.StartAsync(new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);

Console.WriteLine("Consumer Started...");

Console.ReadKey();