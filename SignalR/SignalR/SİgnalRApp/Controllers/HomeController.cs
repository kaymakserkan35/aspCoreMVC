using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SİgnalRApp.Hubs;
using SİgnalRApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SİgnalRApp.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<ChatHub> hubContext;

        public HomeController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            
            return View();

        }
        public IActionResult Index2()
        {
            hubContext.Clients.All.SendAsync("receiveMethod", "1 alana 1 bedava indirimlerimiz başlamıştır");
            return View();
        }





    }
}
