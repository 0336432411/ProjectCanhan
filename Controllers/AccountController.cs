using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCaNhan.Filter;
using ProjectCaNhan.Models;


namespace ProjectCaNhan.Controllers
{
  // [StaffAuth]
  public class AccountController : Controller
  {

    private readonly ApplicationDBContext _db;
    public AccountController(ApplicationDBContext db)
    {
      this._db = db;
    }

    public IActionResult Index()
    {
      var mylist = this._db.Accounts.Where(a => a.Roles == 2 || a.Roles == 3).ToList();
      return View(mylist);
    }
    
    public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Account acc)
        {
           
            this._db.Accounts.Add(acc);
            this._db.SaveChanges();
            return RedirectToAction("Index", "Account");
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

    public IActionResult Delete(int id)
    {
      Account acc = this._db.Accounts.Find(id);
      if (acc == null)
      {
        return NotFound();
      }
      return View(acc);
    }

    [HttpPost]
    public IActionResult DeleteAccount(int id)
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

