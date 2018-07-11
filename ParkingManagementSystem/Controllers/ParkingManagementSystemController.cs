using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingManagementSystem.Controllers
{
    public class ParkingManagementSystemController : Controller
    {
        // GET: ParkingManagementSystem
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult ParkingSpotForm()
        {
            return View();
        }
    }

    
}