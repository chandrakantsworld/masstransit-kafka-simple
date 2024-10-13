# MassTransit Kafka Integration

This project demonstrates a simple implementation of a Kafka producer and consumer using MassTransit. It includes two main components: a producer that sends messages to a Kafka topic and a consumer that listens for messages from the same topic.

## Project Structure

- **MassTransit.Kafka.Consumer**: Contains the consumer application that listens to messages from a Kafka topic.
- **MassTransit.Kafka.Producer**: Contains the producer application that sends messages to a Kafka topic.

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Kafka running locally on `localhost:9092`

## NuGet Packages Used

The project utilizes the following NuGet packages:

- `MassTransit`: A distributed application framework for .NET.
- `MassTransit.Kafka`: Provides Kafka integration for MassTransit.
- `Confluent.Kafka`: A .NET client for Apache Kafka.

## Getting Started

### Running the Consumer

1. Navigate to the `MassTransit.Kafka.Consumer` directory.
2. Run the consumer application:
   ```bash
   dotnet run
   ```
3. Enter messages in the console to send them to the Kafka topic. Type q to quit.
### Configuration
Both the producer and consumer are configured to connect to a Kafka broker running on localhost:9092. The topic name used is topicName-medium, and the consumer group is consumer-group-medium.

#### Consumer Configuration
- Configured in MassTransit.Kafka.Consumer/Program.cs.
- Uses KafkaMessageConsumer to process incoming messages.

#### Producer Configuration
- Configured in MassTransit.Kafka.Producer/Program.cs.
- Sends messages to the Kafka topic using ITopicProducer<IMessage>.

#### Customization
To customize the topic name, consumer group, or Kafka broker address, modify the constants in the respective Program.cs files for both the producer and consumer.

#### License
This project is licensed under the MIT License. See the LICENSE file for more information.

#### Acknowledgments
MassTransit Documentation
Confluent Kafka Documentation