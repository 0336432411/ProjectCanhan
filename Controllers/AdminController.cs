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
    public class AdminController : Controller
    {
             private readonly ApplicationDBContext _db;
    public AdminController(ApplicationDBContext db)
    {
      this._db = db;
    }

    public IActionResult Index()
    {
       var list = this._db.Accounts.ToList();

        return View(list);
    }

         public IActionResult Edit(int id)
    {
      Account acc = this._db.Accounts.Find(id);
      if (acc == null)
      {
        return NotFound();
      }
      return View(acc);
    }
    [HttpPost]
    public IActionResult Edit(Account account)
    {
      if (ModelState.IsValid)
      {
        this._db.Accounts.Update(account);
        this._db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View();
    }

       public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Create()
        {
            // TODO: Your code here
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account acc)
        {
           
            this._db.Accounts.Add(acc);
            this._db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Delete(int id)
        {
            Account acc = this._db.Accounts.Find(id);
            
                return View(acc);
            
            
        }
            [HttpPost]
        public IActionResult DeleteStaff(int id)
        {
             Account acc = this._db.Accounts.Find(id);
      if (acc == null)
      {
        return NotFound();
      }
      else
      {
        this._db.Accounts.Remove(acc);
        this._db.SaveChanges();
        return RedirectToAction("Index");
      }
        }
    }
}