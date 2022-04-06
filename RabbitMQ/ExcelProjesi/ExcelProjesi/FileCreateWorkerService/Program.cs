using ExcelProjesi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using UdemRabbitMQWeb.ExcelCreate.Services;

namespace FileCreateWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    var Configuration = hostContext.Configuration.GetSection("");
                    services.AddDbContext<ApplicationContext>(options =>
                    {
                        options.UseMySql(Configuration.GetConnectionString("ConntextionString"),
                            ServerVersion.AutoDetect(Configuration.GetConnectionString("ConntextionString")));
                    });

                    services.AddSingleton(serviceProvider =>
                      new ConnectionFactory()
                      {
                          Uri = new Uri("amqps://qyqyrpba:tXOh9cV7AEXOGxx_r4o5dteyLk-M0Wh5@fish.rmq.cloudamqp.com/qyqyrpba"),
                          //asenkron method kullandığımızdan dolayı
                          DispatchConsumersAsync = true
                      });
                    //services.AddSingleton<RabbitMQClientService>();
                    // services.AddSingleton<Publisher>();

                    services.AddSingleton<RabbitMQClientService>();
                    services.AddSingleton(sp => new ConnectionFactory() { Uri = new Uri("amqps://qyqyrpba:tXOh9cV7AEXOGxx_r4o5dteyLk-M0Wh5@fish.rmq.cloudamqp.com/qyqyrpba"), DispatchConsumersAsync = true });
                    services.AddHostedService<Worker>();
                });
    }
}
