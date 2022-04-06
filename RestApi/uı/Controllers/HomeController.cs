using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using uı.Models;


namespace uı.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Index()
        {
            string apiUrl = @"https://localhost:44326/Books";
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);

            var serializer = new JavaScriptSerializer();
            List<BookModel> books1 = serializer.Deserialize<List<BookModel>>(json);
            List<BookModel> books2 = JsonSerializer.Deserialize<List<BookModel>>(json);

            return View();
        }

        public IActionResult Server()
        {
            string apiUrl = @"https://localhost:44326/Books";
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);

            var serializer = new JavaScriptSerializer();
            List<BookModel> books1 = serializer.Deserialize<List<BookModel>>(json);
            List<BookModel> books2 = JsonSerializer.Deserialize<List<BookModel>>(json);

            return View(books1);
        }

    }
}
