using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using static WebApi.Common.GlobalExceptionsFilter;

namespace WebApi.Common.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
   
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IHostingEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostingEnvironment env
           )
        {
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                
                WriteLog("",e);
                throw;
            }
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        public void WriteLog(string throwMsg, Exception ex)
        {


            logger.Error(string.Format("【自定义错误】：{0} 【异常类型】：{1} 【异常信息】：{2} 【堆栈调用】：{3}", new object[] { throwMsg+CommonLib.Helpers.Common.Line,
                ex.GetType().Name+CommonLib.Helpers.Common.Line, ex.Message+CommonLib.Helpers.Common.Line, ex.StackTrace+CommonLib.Helpers.Common.Line }));
        }
    }
}
