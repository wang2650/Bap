using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Output;
using WXQ.InOutPutEntites.Input.LogManage.NLog;

namespace WebApi.Controllers.LogManage
{
    /// <summary>
    /// 调试日志
    /// </summary>
    [Route("Api/LogManage/NLog")]
    [ApiController]
    public class NLogController : Controller
    {




        /// <summary>
        /// 查找调试日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetNLogList")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetNLogList([FromForm]  WXQ.InOutPutEntites.Input.LogManage.NLog.GetNLogListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetNLogListInputModelValidation validator = new GetNLogListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.opLogManager.NLogOp op = new WXQ.BusinessCore.opLogManager.NLogOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.nlog> rv = op.GetNLogList(model.application, model.level,model.message, model.bgDt, model.endDt,model.Logger,model.CallSite, pagemodel);

                if (rv == null)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
                else
                {
                    result.Data = rv;
                }
            }

            return Json(result);
        }




        /// <summary>
        /// 删除调试日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult Delete([FromForm]  WXQ.InOutPutEntites.Input.LogManage.NLog.DeleteInput model)
        {
            ResponseResult result = new ResponseResult();

            DeleteInputModelValidation validator = new DeleteInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.opLogManager.NLogOp op = new WXQ.BusinessCore.opLogManager.NLogOp();



                bool rv = op.Delete(model.application, model.level, model.message, model.bgDt, model.endDt, model.Logger, model.CallSite);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
                else
                {
                    result.Data = rv;
                }
            }

            return Json(result);
        }
















    }
}
