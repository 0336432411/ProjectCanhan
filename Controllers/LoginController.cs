using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using ProjectCaNhan.Models;


namespace ProjectCaNhan.Controllers
{

    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _db;
        private readonly SendMailService _sendMailService;
    

        public LoginController(ApplicationDBContext db, SendMailService sendMailService)
        {
            _db = db;
            _sendMailService = sendMailService;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            TempData["LoginError"] = "Username or Password is not correct!";
            Account acc = _db.Accounts.FirstOrDefault(x => (x.Username == username || x.Email == username) && x.Password == password);

            if (acc == null)
            {
                return View(acc);
            }
            else
            {
                const string userName = "_UserName";

                if (acc.Roles == 1)
                {
                    HttpContext.Session.SetString(userName, username.ToString());
                    return RedirectToAction("Index", "Admin");
                }
                else if (acc.Roles == 2)
                {
                    HttpContext.Session.SetString(userName, username.ToString());
                    return RedirectToAction("Index", "Account");
                }
                else if (acc.Roles == 3)
                {
                    HttpContext.Session.SetString(userName, username.ToString());
                    return RedirectToAction("UserProfile", "User", new { id = acc.Id });
                }
                {
                    return View();
                }

            }



            // return NotFound();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
        }

    [HttpPost]
    public IActionResult Register(Account acc)
    {
      this._db.Accounts.Add(acc);
      this._db.SaveChanges();
      return RedirectToAction("Login", "Login");
    }

   
    public IActionResult ForgotPassword()
    {
        // TODO: Your code here
        return View();
    }
    [HttpPost]
    public IActionResult ForgotPassword(Account acc)
    {
        var acc1 = this._db.Accounts.FirstOrDefault(x => x.Email == acc.Email);
        if (acc1 == null)
        {
            ModelState.AddModelError("Email", "Email not exits"); 
            return View("ForgotPassword");
        }
        var otpcode = GenerationOTP();
        var otp = new OTP{
            Email = acc1.Email,
            Otp = otpcode,
            ExpirationTime = DateTime.Now.AddMinutes(6),

        };
        var Send = new MailContent{
            To = acc.Email,
            Subject = "Forgot password",
            Body = $"<h1>Welcome to our application Forget Password!</h1><p>Your OTP code is: {otpcode}</p>"
        };
        HttpContext.Session.SetString("OTPCode", JsonConvert.SerializeObject(otp));
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(acc1));
            var result = _sendMailService.SendMail(Send);
        return RedirectToAction("ResetPassword");
    }

    public IActionResult ResetPassword()
    {
        // TODO: Your code here
        return View();
    }

    [HttpPost]

    public IActionResult ResetPassword(Account Email)
    {
       
        return View();
    }
    

    



    private string GenerationOTP(){
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }
    
    
    public IActionResult Changepass()
    {
      // TODO: Your code here
      return View();
    }

    }

    
}
