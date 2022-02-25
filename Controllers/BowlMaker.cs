﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinghBowlShop.Controllers
{
    public class BowlMaker : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Aboutus(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
