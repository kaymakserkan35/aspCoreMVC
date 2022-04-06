using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myApp.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.webuı.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseSettings settings;
        public HomeController(IOptions<DatabaseSettings> settings)
        {
            this.settings = settings.Value;
        }
        //Action methods
        public IActionResult Index()
        {
            return View();
        }
    }
}
