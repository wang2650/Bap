using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Common.MiddleWare
{
    /// <summary>
    /// 不验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }

    }
    /// <summary>
    /// 验证
    /// </summary>

        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {


        public string AccessKey { get; set; }


        public virtual void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));
          
            //filterContext.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { name = "kxy1" });

            var identity = new CustomIdentity("10");

            var principal = new ClaimsPrincipal(identity);
            filterContext.HttpContext.User = principal;
        }

    }
}
