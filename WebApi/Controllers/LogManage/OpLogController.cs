using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Input.LogManage.OpLog;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.LogManage
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [Route("Api/LogManage/OpLog")]
    [ApiController]
    public class OpLogController : Controller
    {
        /// <summary>
        /// 查找操作日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOpLogList")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetOpLogList([FromForm]  WXQ.InOutPutEntites.Input.LogManage.OpLog.GetOpLogListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetOpLogListInputModelValidation validator = new GetOpLogListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.opLogManager.OpLogOp op = new WXQ.BusinessCore.opLogManager.OpLogOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.OpLog> rv = op.GetOpLogList(model.methodName, model.opUserId, model.bgDt, model.endDt, model.Ip, pagemodel);

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
        /// 删除操作日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult Delete([FromForm]  WXQ.InOutPutEntites.Input.LogManage.OpLog.DeleteInput model)
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
                WXQ.BusinessCore.opLogManager.OpLogOp op = new WXQ.BusinessCore.opLogManager.OpLogOp();

                bool rv = op.Delete(model.methodName, model.opUserId, model.bgDt, model.endDt, model.Ip);

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