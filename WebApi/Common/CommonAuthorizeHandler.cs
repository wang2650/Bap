using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Common
{
  

    public class CommonAuthorizeRequirement :  AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationRequirement
    {
   
         public CommonAuthorizeRequirement(string name="")
        {

        }


        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameAuthorizationRequirement requirement)
        {
            var filterContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext);
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)?.HttpContext;
        
            //var userContext = httpContext.RequestServices.GetService(typeof(UserContext)) as UserContext;

            //var jwtOption = (httpContext.RequestServices.GetService(typeof(IOptions<JwtOption>)) as IOptions<JwtOption>).Value;

            #region 身份验证，并设置用户Ruser值

            var result = httpContext.Request.Headers.TryGetValue("Authorization", out StringValues authStr);
            if (!result || string.IsNullOrEmpty(authStr.ToString()))
            {
                return Task.CompletedTask;
            }

            var jwtuserModel = JwtHelper.DerializeJWT(authStr.ToString());

         
            if (jwtuserModel != null  && jwtuserModel.ExpDate> new DateTimeOffset(DateTime.Now.AddHours(1)).ToUnixTimeSeconds())
            {
             

                var identity = new CustomIdentity(jwtuserModel.Uid.ToString());
              
                var principal = new ClaimsPrincipal(identity);

                httpContext.User = principal;

                context.Succeed(requirement);

                return Task.CompletedTask;
            }
 

            #endregion
   

           
            return Task.CompletedTask;
        }






    }



}
