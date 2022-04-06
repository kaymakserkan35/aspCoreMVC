using Microsoft.AspNetCore.Mvc;
using myApp.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.webuı.Controllers
{
    public class HomeController : Controller
    {
        private ITopicAreaService topicAreaService;

        public HomeController(ITopicAreaService topicAreaService)
        {
            this.topicAreaService = topicAreaService;
        }

        public IActionResult Index()
        {
            topicAreaService.GetAllTopicAreas();
            return View();
        }
    }
}
