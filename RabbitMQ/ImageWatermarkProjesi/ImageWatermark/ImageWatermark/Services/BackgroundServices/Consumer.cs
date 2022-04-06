using ImageWatermark.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UdemyRabbitMQWeb.Watermark.BackgroundServices
{
    public class Consumer : BackgroundService
    {
        private readonly RabbitMQService producerService;
        private readonly ILogger<Consumer> _logger;
        private IModel _channel;
        public Consumer(RabbitMQService producerService, ILogger<Consumer> logger)
        {
            this.producerService = producerService;
            _logger = logger;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = producerService.CreateConnection();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMQService.QueueName, false, consumer);
            consumer.Received += Consumer_Received;
            return Task.CompletedTask;

        }

        private Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            Task.Delay(10000).Wait();

            try
            {
                var productImageCreatedEvent = JsonSerializer.Deserialize<DataCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", productImageCreatedEvent.ImageName);
                var siteName = "wwww.mysite.com";
                using var img = Image.FromFile(path);
                using var graphic = Graphics.FromImage(img);
                var font = new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                var textSize = graphic.MeasureString(siteName, font);
                var color = Color.FromArgb(128, 255, 255, 255);
                var brush = new SolidBrush(color);
                var position = new Point(img.Width - ((int)textSize.Width + 30), img.Height - ((int)textSize.Height + 30));
                graphic.DrawString(siteName, font, brush, position);
                img.Save("wwwroot/Images/WatermarkedImages/" + productImageCreatedEvent.ImageName);
                img.Dispose();
                graphic.Dispose();
                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }


            return Task.CompletedTask;




        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
