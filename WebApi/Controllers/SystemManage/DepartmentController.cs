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
using WXQ.InOutPutEntites.Input.SystemManage.Department;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.systemmanage
{

    /// <summary>
    /// 菜单模块
    /// </summary>

    [Route("Api/SystemManage/Department")]
    [ApiController]
    public class DepartmentController : Controller
    {



        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("InsertDepartment")]
        public JsonResult InsertDepartment([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.InsertDepartmentInput model)
        {
            ResponseResult result = new ResponseResult();

            InsertDepartmentInputModelValidation validator = new InsertDepartmentInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp(userId);

                WXQ.Enties.Department r = new WXQ.Enties.Department
                {
                    AddDateTime = DateTime.Now,
                    AddUser = this.User.Identity.Name,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    DepartmentName=model.DepartmentName
                };

                bool rv = op.InsertDepartment(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }



        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("UpdateDepartment")]
        public JsonResult UpdateDepartment([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.UpdateDepartmentInput model)
        {
            ResponseResult result = new ResponseResult();

            UpdateDepartmentInputValidation validator = new UpdateDepartmentInputValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp(userId);

                WXQ.Enties.Department r = new WXQ.Enties.Department
                {
                    DepartmentId=model.DepartmentId,
                    UpdateDateTime = DateTime.Now,
                    UpdateUser = this.User.Identity.Name,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    DepartmentName = model.DepartmentName
                };

                bool rv = op.UpdateDepartment(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }





        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("DeleteDepartmentByDepartmentId")]
        public JsonResult DeleteDepartmentByDepartmentId([FromQuery]  int DepartmentId)
        {
            ResponseResult result = new ResponseResult();

            if (DepartmentId < 1)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("部门id错误");
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp(userId);


                bool rv = op.DeleteDepartmentByDepartmentId(DepartmentId);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }




        /// <summary>
        /// 查找部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDepartmentList")]
        [WebApi.Common.Log]
        public JsonResult GetDepartmentList([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.GetDepartmentListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetDepartmentListInputModelValidation validator = new GetDepartmentListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Department> rv = op.GetDepartmentList(model.DepartmentName, model.ParentId, model.Page.PageIndex,model.Page.PageSize);

                if (rv == null)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
                else
                {
                    result.Data =rv;
                }
            }

            return Json(result);
        }


        /// <summary>
        /// 查找用户所在的部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetDepartmentListByUserId")]
        [WebApi.Common.Log]
        public JsonResult GetDepartmentListByUserId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.GetDepartmentListByUserIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetDepartmentListByUserIdInputModelValidation validator = new GetDepartmentListByUserIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Department> rv = op.GetDepartmentListByUserId(model.UserId, model.Page.PageIndex, model.Page.PageSize);

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
        /// 查找当前用户所在的部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepartmentListForCurrentUser")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult GetDepartmentListForCurrentUser()
        {
            ResponseResult result = new ResponseResult();

            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            if (userId<=0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
            }
            else
            {
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp();


                ListResult<WXQ.Enties.Department> rv = op.GetDepartmentListByUserId(userId, 1, 200);

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
        /// 查找当前用户所在的部门和子部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDepartmentAndSubDepartmentForCurrentUser")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult GetDepartmentAndSubDepartmentForCurrentUser()
        {
            ResponseResult result = new ResponseResult();

            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            if (userId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
            }
            else
            {
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp();


               var  rv= op.GetDepartmentAndSubDepartmentByUserId(userId, 1, 200);

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
        /// 查找部门中的用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserListByDepartmentId")]
        public JsonResult GetUserListByDepartmentId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.GetUserListByDepartmentIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetUserListByDepartmentIdInputModelValidation validator = new GetUserListByDepartmentIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp();


                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Users> rv = op.GetUserListByDepartmentId(model.DepartmentId, model.Page.PageIndex, model.Page.PageSize);

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
        /// 添加部门的用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUserForDepartment")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult AddUserForDepartment([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.ModifyUserForDepartmentInput model)
        {
            ResponseResult result = new ResponseResult();

            ModifyUserForDepartmentInputModelValidation validator = new ModifyUserForDepartmentInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp(userId);


              bool rv = op.AddUserForDepartment(model.DepartmentId, model.UserIds);

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
        /// 移除部门中的用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RemoveUserForDepartment")]
        [WebApi.Common.Log]
        [Authorize("common")]
        public JsonResult RemoveUserForDepartment([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Department.ModifyUserForDepartmentInput model)
        {
            ResponseResult result = new ResponseResult();

            ModifyUserForDepartmentInputModelValidation validator = new ModifyUserForDepartmentInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.DepartmentOp op = new WXQ.BusinessCore.systemmanage.DepartmentOp(userId);


                bool rv = op.DeleteUserForDepartment(model.DepartmentId, model.UserIds);

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
