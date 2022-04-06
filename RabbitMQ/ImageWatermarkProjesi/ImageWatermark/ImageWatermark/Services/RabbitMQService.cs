using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageWatermark.Services
{
    public class RabbitMQService : IDisposable
    {

        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "ImageDirectExchange";
        public static string RoutingWatermark = "watermark-route-image";
        public static string QueueName = "queue-watermark-image";

        private readonly ILogger<RabbitMQService> _logger;

        public RabbitMQService(ConnectionFactory connectionFactory, ILogger<RabbitMQService> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;

        }

        public IModel CreateConnection()
        {
            _connection = _connectionFactory.CreateConnection();


            if (_channel is { IsOpen: true })
            {
                //channel açıksa bu channelı dön
                return _channel;
            }
            else // dehil ise channel üret
            {
                //exchange declare
                //kuyruk declere
                //kuyruk bind
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);
                _channel.QueueDeclare(QueueName, true, false, false, null);
                _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingWatermark);
                _logger.LogInformation("RabbitMQ ile bağlantı kuruldu...");
                return _channel;
            }


        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();
            _logger.LogInformation("RabbitMQ ile bağlantı kapatıldı...");
        }




    }
}
