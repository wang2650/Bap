using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Common.MiddleWare
{
    public class ResponseTimeMiddleware
    {
       

        private readonly RequestDelegate _next;
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {

            context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            context.Response.Headers["Access-Control-Allow-Methods"] = "POST, GET, OPTIONS, PUT, PATCH, DELETE";
            context.Response.Headers["Access-Control-Allow-Headers"] = "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, authorization , Access-Control-Request-Headers,Referer,User-Agent";
            if (context.Request.Method.ToLower() == "options")
            {
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }
          

            return this._next(context);
        }
    }
}
