﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }   

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }
    }
}
