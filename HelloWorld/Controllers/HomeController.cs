using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Update(int carId, string carName, string carMake, string carYear, string carModel)
        {
            ViewBag.Details = new Car()
            {
                Id = carId,
                Name = carName,
                Make = carMake,
                Year = carYear,
                Model = carModel,
            };

            return View();
        }

        public ActionResult Store()
        {
            return View();
        }
    }
}
