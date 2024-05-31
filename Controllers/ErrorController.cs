using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectCaNhan.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage()
        {
            // TODO: Your code here
            return View();
        }

        public IActionResult Changehome()
        {
            return RedirectToAction("UserProfile","User");
           
        }
        
        
    }
}