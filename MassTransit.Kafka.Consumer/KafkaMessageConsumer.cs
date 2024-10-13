using System;
using Confluent.Kafka;
using MassTransit.Kafka.Shared;
using MassTransit.KafkaIntegration;

namespace MassTransit.Kafka.Consumer;

public class KafkaMessageConsumer : IConsumer<IMessage>
{
    public Task Consume(ConsumeContext<IMessage> context)
    {
       var ctx = (context.ReceiveContext as KafkaReceiveContext<Ignore,IMessage>);
       Console.WriteLine($"Message: {context.Message.Text}, Offset: {ctx?.Offset}");
       return Task.CompletedTask;
    }
}
