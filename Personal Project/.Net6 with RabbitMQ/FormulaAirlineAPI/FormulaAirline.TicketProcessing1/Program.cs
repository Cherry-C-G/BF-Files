// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Welcom to the ticketing service");
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/"
};
var conn = factory.CreateConnection();
using var channel = conn.CreateModel();
channel.QueueDeclare("bookings", durable: true, exclusive: true);
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    //getting my byte[]
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"New ticket processing is initiated - {message}");
};
channel.BasicConsume("bookings", true, consumer);
Console.ReadKey();
