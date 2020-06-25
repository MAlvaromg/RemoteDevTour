using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace mywebapp.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        int brothers = 3;

        public HomeController()
        {
            client = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Lottery()
        {
            
            var price = 100000000;
            var moneyPerPerson = price / brothers;

            ViewData["Message"] = moneyPerPerson;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Quotes()
        {
            var response = await client.GetStringAsync("http://demowebapi:9000/api/quotes");
            ViewData["Message"] = response; //"Sessions";
            
            return View();
         }
    }
}
