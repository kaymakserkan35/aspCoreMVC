
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using UdemyRabbitMQWeb.Watermark.BackgroundServices;

namespace ImageWatermark.Services
{
    public class Producer
    {
        private readonly RabbitMQService producerService;

       
        public Producer(RabbitMQService producerService)
        {
            this.producerService = producerService;
          
        }

        public void Publish(DataCreatedEvent dataCreatedEvent)
        {
            var channel = producerService.CreateConnection();

            var bodyString = JsonConvert.SerializeObject(dataCreatedEvent);

            var bodyByte = Encoding.UTF8.GetBytes(bodyString);

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(exchange: RabbitMQService.ExchangeName, routingKey: RabbitMQService.RoutingWatermark, basicProperties: properties, body: bodyByte);

        }
    }
}
