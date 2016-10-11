using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Controllers.Api
{
    public class DemoController : Controller
    {
        [HttpGet("/api/demo")]
        public IActionResult Get()
        {
            // Here you can retrieve info from objects and return them along with the http request

            string myString = "This string is returned to browser when user submits a GET request when visiting this route (localhost:port/api/demo)";

            return Ok(myString);    // Ok returns a 200 Ok page
        }
    }
}
