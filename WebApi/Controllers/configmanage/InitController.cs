using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.configmanage
{
    [Route("Api/Configmanage/Init")]
    [ApiController]
    public class InitController : Controller
    {
   
        /// <summary>
        /// 初始化数据库  执行完请注释掉该方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("InitDataBase")]
        public JsonResult InitDataBase()
        {
            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
        
            logger.Info("ddddddd");

            logger.Info("aaaaaaaaaaaaaaaa");

            return Json(result);
        }
    }
}