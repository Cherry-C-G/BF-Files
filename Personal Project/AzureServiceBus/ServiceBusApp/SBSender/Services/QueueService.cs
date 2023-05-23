using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace SBSender.Services
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _config;
        public QueueService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendMessageAsync<T>(T ServiceBusMessage, string queueName)
        {
            var queueClient = new QueueClient(_config.GetConnectionString("AzureServiceBus"), queueName);//setting connection,queue
            string messageBody = JsonSerializer.Serialize(ServiceBusMessage);//serialize data
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));   //convert byte array
            await queueClient.SendAsync(message);//send message to Service Bus, this method contains these steps is always the same
        }
    }
}
