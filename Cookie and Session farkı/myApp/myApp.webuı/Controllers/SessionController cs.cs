using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.webuı.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            SetSession();

            ViewBag.Session = GetSession();
            return View();
        }

        private void SetSession()
        {
            HttpContext.Session.SetString("session_Key", "session_Value");
        }

        private string GetSession()
        {
            return HttpContext.Session.GetString("session_Key");
        }
    }
}
