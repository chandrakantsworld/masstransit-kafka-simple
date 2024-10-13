using MassTransit;
using MassTransit.Kafka.Shared;
using Microsoft.Extensions.DependencyInjection;

var service = new ServiceCollection();

service.AddMassTransit(x =>
{
    const string topicName = "topicName-medium";
    const string kafkaBrokerServer = "localhost:9092";
    x.UsingInMemory((context, cfg) => cfg.ConfigureEndpoints(context));
    x.AddRider(rider =>
    {
        rider.AddProducer<IMessage>(topicName);
        rider.UsingKafka((context, cfg) => cfg.Host(kafkaBrokerServer));
    });
});

var provider = service.BuildServiceProvider();

var busControl = provider.GetRequiredService<IBusControl>();

await busControl.StartAsync(new CancellationTokenSource(TimeSpan.FromSeconds(10)).Token);

var producer = provider.GetRequiredService<ITopicProducer<IMessage>>();

while(true){
    Console.WriteLine("Enter your message:");
    var msg = Console.ReadLine();

    if (msg == "q"){
        break;
    }
    await producer.Produce(new {
        Text=msg
    });

}

Console.ReadKey();