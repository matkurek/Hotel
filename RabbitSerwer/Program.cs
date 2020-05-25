using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Framing.Impl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitSerwer
{
    class MyConsumer : DefaultBasicConsumer
    {
        public MyConsumer(IModel model) : base(model) { }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool
       redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {
            //W zmiennej message update do wykonania
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);

            string connectionString = @"Data Source=DESKTOP-8KLJPV0\MSSQLSERVER01;" +
            "Initial Catalog=Hotel;" +
            "Integrated Security=SSPI;" + "Connection Timeout=1;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand(message, connection);
                // Setting command timeout in seconds:
                command.CommandTimeout = 2;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //if (properties.CorrelationId != null)
                    //{
                    //    var responseBytes = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString() + "Próba insertu zajmuje za długo, więc ją zakończono - prośzę spróbować później \n" + e.ToString());
                    //    var replyProps = Model.CreateBasicProperties();
                    //    replyProps.CorrelationId = properties.CorrelationId;
                    //    Model.BasicPublish("", properties.ReplyTo, replyProps, responseBytes);
                    //}
                }
            }

            //if (properties.CorrelationId != null)
            //{
            //    var responseBytes = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
            //    var replyProps = Model.CreateBasicProperties();
            //    replyProps.CorrelationId = properties.CorrelationId;
            //    Model.BasicPublish("", properties.ReplyTo, replyProps, responseBytes);
            //}
            // show message
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                UserName = "nbmnpwjs",
                Password = "Nij0m4Mdxj4Zxp8F2h1eHZji_VjLoj2a",
                HostName = "bulldog.rmq.cloudamqp.com",
                VirtualHost = "nbmnpwjs"
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("message_queue", false, false, false, null);

                var consumer = new MyConsumer(channel);

                while (true)
                {
                    Thread.Sleep(750);
                    channel.BasicConsume("message_queue", true, consumer);
                }

            }
        }
    }
}
