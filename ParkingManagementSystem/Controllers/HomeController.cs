using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingManagementSystem.Models;

namespace ParkingManagementSystem.Controllers
{
    public class Home : Controller
    {
        // GET: ParkingManagementSystem
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ParkingSpotForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult ParkingSpotForm(UserInfo userInfo)
        {
            return View("Thanks", userInfo);
        }

        [HttpGet]
        public ViewResult CheckOutForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CheckOutForm(UserInfo userInfo)
        {
            return View("Thanks for coming!", userInfo);
        }
    }


}