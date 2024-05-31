using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using ProjectCaNhan.Models;

namespace ProjectCaNhan.Filter
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var acc = context.HttpContext.Session.GetString("_UserName");
            if (string.IsNullOrEmpty(acc))
            {
                context.Result = new RedirectToRouteResult( new RouteValueDictionary(new {controller = "Login", action="Login"}));
            }else
            {
                base.OnActionExecuting(context);
            }
        }
    }

    public class AdminAuth : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext context)
        {
            var acc = context.HttpContext.Session.GetString("_UserName");
            if (string.IsNullOrEmpty(acc))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller = "Login", action = "Login"}));
                return;
            }
            var user = JsonSerializer.Deserialize<Account>(acc);
            if (user.Roles != 1)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller = "Error", action = "ErrorPage"}));
                
            }else
            {
                base.OnActionExecuting(context);
            }
    }
    }

     public class StaffAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var acc = context.HttpContext.Session.GetString("_UserName");
            if (string.IsNullOrEmpty(acc))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller = "Login", action = "Login"}));
                return;
            }
            var user = JsonSerializer.Deserialize<Account>(acc);
            if (user.Roles != 1 && user.Roles != 2)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new {controller = "Error", action = "ErrorPage"}));
                
            }else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}