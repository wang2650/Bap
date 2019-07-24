using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Input.configmanager;
using WXQ.InOutPutEntites.Input.configmanager.Dict;
using WXQ.InOutPutEntites.Output;
namespace WebApi.Controllers.configmanager
{
    /// <summary>
    /// 字典管理
    /// </summary>
    [Route("Api/Configmanage/Dict")]
    [ApiController]
    public class DictController : Controller
    {



        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("InsertDict")]
        public JsonResult InsertDict([FromForm]  WXQ.InOutPutEntites.Input.configmanager.Dict.InsertDictInput model)
        {
            ResponseResult result = new ResponseResult();

            InsertDictInputModelValidation validator = new InsertDictInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp(userId);

                WXQ.Enties.Dict r = new WXQ.Enties.Dict
                {
                   
                    Description = model.Description,
                    DictKey= model.DictKey,
                    DictValue = model.DictValue,
                    DictType=model.DictType,
                    OrderBy=model.OrderBy,
                    GroupName=model.GroupName,
                    CreateTime=DateTime.Now,
                    CreateUser=this.User.Identity.Name
                };

                bool rv = op.InsertDict(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }



        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("UpdateDict")]
        public JsonResult UpdateDict([FromForm]  WXQ.InOutPutEntites.Input.configmanager.Dict.UpdateDictInput model)
        {
            ResponseResult result = new ResponseResult();

            UpdateDictInputModelValidation validator = new UpdateDictInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp(userId);

                WXQ.Enties.Dict r = new WXQ.Enties.Dict
                {
                    Id=model.Id,
                    Description = model.Description,
                    DictKey = model.DictKey,
                    DictValue = model.DictValue,
                    DictType = model.DictType,
                    OrderBy = model.OrderBy,
                    GroupName = model.GroupName,
                    UpdateTime = DateTime.Now,
                    UpdateUser = this.User.Identity.Name
                };

                bool rv = op.UpdateDict(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }



        /// <summary>
        /// 删除字典通过主键
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("DeleteDictByDictId")]
        public JsonResult DeleteDictByDictId([FromForm]  int Id)
        {
            ResponseResult result = new ResponseResult();

   
            if (Id>0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("字典id错误");
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp(userId);

                bool rv = op.DeleteDictByDictId(Id);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }


        /// <summary>
        /// 删除字典根据分组名
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("DeleteDictByGroupName")]
        public JsonResult DeleteDictByGroupName([FromForm]  string GroupName)
        {
            ResponseResult result = new ResponseResult();


            if (!string.IsNullOrEmpty(GroupName))
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("分组名不可为空");
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp(userId);

                bool rv = op.DeleteDictByGroupName(GroupName);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }




        /// <summary>
        /// 搜索列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("GetDictList")]
        public JsonResult GetDictList([FromForm]  WXQ.InOutPutEntites.Input.configmanager.Dict.GetDictListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetDictListInputModelValidation validator = new GetDictListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Dict> rv = op.GetDictList(model.GroupName, pagemodel);

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
        /// 搜索列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("GetDictList")]
        public JsonResult GetDictGroup([FromForm]  WXQ.InOutPutEntites.Input.configmanager.Dict.GetDictListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetDictListInputModelValidation validator = new GetDictListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                model.GroupName = string.IsNullOrEmpty(model.GroupName) ? "dictgroup" : model.GroupName;
                WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Dict> rv = op.GetDictGroup( pagemodel,model.GroupName);

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




    }
}
