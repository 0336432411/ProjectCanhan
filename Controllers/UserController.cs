using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCaNhan.Models;

namespace ProjectCaNhan.Controllers
{
   
    public class UserController : Controller
    {
         private readonly ApplicationDBContext _db;
    public UserController(ApplicationDBContext db)
    {
      this._db = db;
    }

    public IActionResult UserProfile(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var acc = this._db.Accounts.FirstOrDefault(u => u.Id == id);
            ViewBag.Password = acc.Password;

            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }
    }
}