using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Controllers;

namespace UI.Classses
{
    public class HelloWorldJob : IJob
    {

        public int sayac { get; set; } = 0;

        public Task Execute(IJobExecutionContext context)
        {
            this.sayac = sayac + 1;

            string apiUrl = @"http://api.plos.org/search?q=title:%22Drosophila%22%20and%20body:%22RNA%22&fl=id,abstract";
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);


            return Task.CompletedTask;
        }
    }
}
