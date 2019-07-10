using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Threading.Tasks;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Common
{
    /// <summary>
    /// 全局异常处理
    /// </summary>
    public class GlobalExceptionsFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public GlobalExceptionsFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// 异常发生
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            JsonErrorResponse json = new JsonErrorResponse
            {
                Message = context.Exception.Message//错误信息
            };
            if (_env.IsDevelopment())
            {
                json.DevelopmentMessage = context.Exception.StackTrace;//堆栈信息
            }
            if (context.ExceptionHandled == false)
            {

              

                ResponseResult responseResult = new ResponseResult(ResponseResultMessageDefine.Exception, json.Message);
                JsonResult result = new JsonResult(responseResult);

                context.Result = result;
            }
            WriteLog(json.Message, context.Exception);
            context.ExceptionHandled = true; //异常已处理了
          
      
        }
        /// <summary>
        /// 异步处理异常
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)

        {

            OnException(context);

            return Task.CompletedTask;

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
        /// <summary>
        /// 服务器端异常
        /// </summary>
        public class InternalServerErrorObjectResult : ObjectResult
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            public InternalServerErrorObjectResult(object value) : base(value)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }

  
        /// <summary>
        /// 返回错误信息
        /// </summary>
        public class JsonErrorResponse
        {
            /// <summary>
            /// 生产环境的消息
            /// </summary>
            public string Message { get; set; }

            /// <summary>
            /// 开发环境的消息
            /// </summary>
            public string DevelopmentMessage { get; set; }
        }
    }
}