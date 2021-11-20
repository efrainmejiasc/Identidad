
using IdentidadSite.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdentidadSite.Filters
{
    public class ValidateSession : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor httpContext;

        public ValidateSession()
        {
            this.httpContext = new HttpContextAccessor();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try 
            { 
                base.OnActionExecuting(filterContext);

                if (string.IsNullOrEmpty(this.httpContext.HttpContext.Session.GetString("UserLogin")) )
                {
                    if (filterContext.Controller is HomeController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Index");
                    }

                }
            }
            catch 
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}
