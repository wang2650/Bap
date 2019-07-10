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
using WXQ.InOutPutEntites.Input.LogManage.Metrics;

namespace WebApi.Controllers.LogManage
{
    /// <summary>
    /// 度量日志
    /// </summary>
    [Route("Api/LogManage/Metrics")]
    [ApiController]
    public class MetricsController : Controller
    {



        /// <summary>
        /// 查找度量日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMetricsList")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetMetricsList([FromForm]  WXQ.InOutPutEntites.Input.LogManage.Metrics.GetMetricsListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetMetricsListInputModelValidation validator = new GetMetricsListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.opLogManager.MetricsOp op = new WXQ.BusinessCore.opLogManager.MetricsOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Metrics> rv = op.GetMetricsList(model.MethodName, model.CostTime, model.BgDt,model.EndDt, pagemodel);

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
        /// 删除度量日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult Delete([FromForm]  WXQ.InOutPutEntites.Input.LogManage.Metrics.DeleteInput model)
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
                WXQ.BusinessCore.opLogManager.MetricsOp op = new WXQ.BusinessCore.opLogManager.MetricsOp();

               bool rv = op.Delete(model.MethodName, model.CostTime, model.BgDt, model.EndDt);

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
