using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Input.SystemManage.Role;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.systemmanage
{
    /// <summary>
    /// 角色模块
    /// </summary>

    [Route("Api/SystemManage/Role")]
    [ApiController]
    public class RoleController : Controller
    {

        #region  增删改
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("InsertRole")]
        public JsonResult InsertRole([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.InsertRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            InsertRoleInputModelValidation validator = new InsertRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {    int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp(userId);
            
                WXQ.Enties.Role r = new WXQ.Enties.Role
                {
                    AddDateTime = DateTime.Now,
                    AddUser = userId.ToString(),
                    Description = model.Description,
                    RoleName = model.RoleName
                };

                bool rv = op.InsertRole(r,model.DepartmentId);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("UpdateRole")]
        public JsonResult UpdateRole([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.UpdateRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            UpdateRoleInputModelValidation validator = new UpdateRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {         int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp(userId);
       
                WXQ.Enties.Role r = new WXQ.Enties.Role
                {
                    RoleId = model.RoleId,
                    AddDateTime = DateTime.Now,
                    AddUser = userId.ToString(),
                    Description = model.Description,
                    RoleName = model.RoleName
                };

                bool rv = op.UpdateRole(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("DeleteRoleByRoleId")]
        public JsonResult DeleteRoleByRoleId([FromQuery]  int Id)
        {
            ResponseResult result = new ResponseResult();

            if (Id <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("角色id错误");
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp(userId);

                bool rv = op.DeleteRoleByRoleId(Id);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        #endregion

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRoleList")]
        [WebApi.Common.Log]
        public JsonResult GetRoleList([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.GetRoleListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetRoleListInputModelValidation validator = new GetRoleListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Role> rv = op.GetRoleList(model.RoleName,  pagemodel, model.DepartmentId);

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
        /// 查找用户所属的角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRoleListByUserId")]
        [WebApi.Common.Log]
        public JsonResult GetRoleListByUserId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.GetRoleListByUserIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetRoleListByUserIdInputModelValidation validator = new GetRoleListByUserIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Role> rv = op.GetRoleListByUserId(model.UserId, model.Page.PageIndex, model.Page.PageSize);

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
        /// 查找角色包含的用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsersListByRoleId")]
        [WebApi.Common.Log]
        public JsonResult GetUsersListByRoleId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.GetUsersListByRoleIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetUsersListByRoleIdInputModelValidation validator = new GetUsersListByRoleIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Users> rv = op.GetUsersListByRoleId(model.RoleId, model.Page.PageIndex, model.Page.PageSize);

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
        /// 添加用户到角色
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUserForRole")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult AddUserForRole([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.AddUserForRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            AddUserForRoleInputModelValidation validator = new AddUserForRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp();



                bool rv = op.AddUserForRole(model.RoleId, model.UserIds);

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



        /// <summary>
        /// 从角色移除用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RemoveUserFromRole")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult RemoveUserFromRole([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Role.AddUserForRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            AddUserForRoleInputModelValidation validator = new AddUserForRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.RoleOp op = new WXQ.BusinessCore.systemmanage.RoleOp();



                bool rv = op.RemoveUserFromRole(model.UserIds,model.RoleId );

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