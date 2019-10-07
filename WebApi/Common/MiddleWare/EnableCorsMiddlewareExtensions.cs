using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Common.MiddleWare
{


    public static class EnableCorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseEnableCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnableCorsMiddleware>();
        }
    }
}
