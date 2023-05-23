using Microsoft.Azure.ServiceBus;
using System.Text.Json;
using SBShared.Models;
using System;
using System.Text;

namespace SBReceiver
{
    class Program
    {
        const string connectionString = "Endpoint=sb://timcoservicebus.servicebus.windows.net/;SharedAd...";
        const string queueName = "personqueue";
        static IQueueClient queueClient;
        static async Task Main(string[] args)
        {
            queueClient = new QueueClient(connectionString, queueName);
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);//listen for changes
            Console.ReadLine();//close when it's done
            await queueClient.CloseAsync();
        }

        private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            var jsonString = Encoding.UTF8.GetString(message.Body);
            PersonModel person = JsonSerializer.Deserialize<PersonModel>(jsonString);
            Console.WriteLine($"Person Received:{person.FirstName} {person.LastName}");
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler exception:{arg.Exception}");
            return Task.CompletedTask;
        }
    }
}