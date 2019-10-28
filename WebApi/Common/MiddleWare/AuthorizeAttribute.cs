using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Security.Claims;

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

            var result = filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authStr);
            if (!result || string.IsNullOrEmpty(authStr.ToString()))
            {
                filterContext.Result = new UnauthorizedResult();
            }
            else
            {
                var jwtuserModel = JwtHelper.DerializeJWT(authStr.ToString());

                if (jwtuserModel != null && jwtuserModel.ExpDate > new DateTimeOffset(DateTime.Now.AddHours(1)).ToUnixTimeSeconds())
                {
                    var identity = new CustomIdentity(jwtuserModel.Uid.ToString());

                    var principal = new ClaimsPrincipal(identity);

                    filterContext.HttpContext.User = principal;
                }
            }
        }
    }
}