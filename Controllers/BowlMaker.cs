using Microsoft.AspNetCore.Mvc;
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
    }
}
