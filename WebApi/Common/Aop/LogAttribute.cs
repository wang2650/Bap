using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UAParser.FormFactor;
using UAParser.FormFactor.Models;

namespace WebApi.Common
{
    /// <summary>
    /// 记录操作日志
    /// </summary>
    public class LogAttribute :   ActionFilterAttribute
    {



        /// <summary>
        /// 添加操作日志 liyouming
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actiondescriptor = ((ControllerActionDescriptor)context.ActionDescriptor);
            var identity = context.HttpContext.User.Identity;
       
            string model =string.Empty;
            if (context.HttpContext.Request.Method.ToLower()=="get") {

                model = JsonConvert.SerializeObject(context.HttpContext.Request.Query);
            }
            else
            {
                if (context.HttpContext.Request.Body!=null)
                {
                    model = context.HttpContext.Request.Body.ToString();
                    model = model.Length > 8000 ? model.Substring(0, 4000) : model;

                }

               
            }

            ClientInfo clientInfo = Parser.GetDefault().Parse(context.HttpContext.Request.Headers["User-Agent"]);


            WXQ.Enties.OpLog m = new WXQ.Enties.OpLog();
            m.Ip = context.HttpContext.Connection.RemoteIpAddress.ToString(); 
            m.AppId = 1;
            m.Brower ="设备"+ clientInfo.Device.Family + clientInfo.Device.FormFactor + "操作系统" + clientInfo.OS.Family  + "浏览器" + clientInfo.UserAgent.Family  + "版本" + clientInfo.UserAgent.Major;
            m.ControllerName = actiondescriptor.ControllerName;
            m.CreateDateTime = DateTime.Now;
            m.MethodName = actiondescriptor.ActionName;
            m.OpUser = context.HttpContext.User == null ? 0: (context.HttpContext.User.Identity ==null? 0: (string.IsNullOrEmpty( context.HttpContext.User.Identity.Name)?0:Convert.ToInt32(context.HttpContext.User.Identity.Name)));
            m.ParaValue = model.Length > 3000 ? model.Substring(0, 3000) : model;

            WXQ.BusinessCore.opLogManager.OpLogOp.InsertOplog(m);
        }

        /// <summary>
        /// 读取request 的提交内容
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        /// <returns></returns>
        public string GetRequestValues(ActionExecutedContext actionExecutedContext)
        {

        return    JsonConvert.SerializeObject(actionExecutedContext.Result);
     
            
        }
    }
}
