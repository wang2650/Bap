using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
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
        [Route("InitDataBase")]
        public JsonResult InitDataBase()
        {
            ResponseResult result = new ResponseResult();
            Logger logger = LogManager.GetLogger("initlog");
            try
            {
                logger.Info("初始化数据库开始");
                WXQ.BusinessCore.systemmanage.InitOp op = new WXQ.BusinessCore.systemmanage.InitOp(0);

                result.Data = op.InitSql();
                logger.Info("初始化数据库结束");
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                logger.Info("初始化数据库失败");
                logger.Info(ex.Message);
            }
            return Json(result);
        }
    }
}