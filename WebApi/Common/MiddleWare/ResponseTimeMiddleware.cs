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
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task InvokeAsync(HttpContext context)
        {


            context.Response.Headers["server"] = "Tengine/1.1";
            context.Response.Headers["x-powered-by"] = "";
            context.Response.Headers["x-powered-by"] = "wxq";
            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();

                WXQ.Enties.Metrics m = new WXQ.Enties.Metrics();
                m.MethodName = context.Request.Path;
                m.AppId = 1;
                m.CreateDateTIme = DateTime.Now;
                //秒
                m.CostTime =Convert.ToInt32 ( responseTimeForCompleteRequest/1000);


                WXQ.BusinessCore.opLogManager.MetricsOp.InsertMetricsLog(m);


                return Task.CompletedTask;
            });
            // Call the next delegate/middleware in the pipeline   
            return this._next(context);
        }
    }
}
