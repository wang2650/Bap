using CommonLib.Extensions;
using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using WebApi.Common;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Input.SystemManage.User;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.systemmanage
{
    /// <summary>
    /// 用户模块
    /// </summary>
    [DisableCors]
    [Route("Api/SystemManage/User")]
    [ApiController]
    [EnableCors("any")]
    public class UserController : Controller
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        [HttpGet]
        [WebApi.Common.Log]
        [Route("DeleteUser")]
        [WebApi.Common.MiddleWare.AuthorizeAttribute]
        public JsonResult DeleteUser([FromQuery] int userId)
        {
            ResponseResult result = new ResponseResult();

            int opUserId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
            WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(opUserId);

            bool isSuccess = op.DeleteUsersByUsersId(userId);

            if (!isSuccess)
            {
                result.Code = ResponseResultMessageDefine.OpLost;

                result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
            }

            return Json(result);
        }

        /// <summary>
        /// 当前用户的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCurrentUserInfo")]
        [WebApi.Common.MiddleWare.AuthorizeAttribute]
        [WebApi.Common.Log]
        public JsonResult GetCurrentUserInfo()
        {

           
            ResponseResult result = new ResponseResult();
            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp();

            WXQ.Enties.Users rv = op.GetUserByUserId(userId);

            if (rv == null)
            {
                result.Code = ResponseResultMessageDefine.OpLost;
                result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
            }
            else
            {
                result.Data = rv;
            }

            return Json(result);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUserList")]
        [WebApi.Common.Log]
        public JsonResult GetUserList([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.GetUserListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetUserListInputModelValidation validator = new GetUserListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Users> rv = op.GetUserList(model.UserName, pagemodel, model.RsState);

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
        /// 添加
        /// </summary>
        /// <param name="model">参数</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("InsertUser")]
        public JsonResult InsertUser([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.InsertInput model)
        {
            ResponseResult result = new ResponseResult();

            InsertInputModelValidation validator = new InsertInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(userId);
                WXQ.Enties.Users userModel = new WXQ.Enties.Users
                {
                    UserName = model.UserName,
                    AddDateTime = DateTime.Now,
                    AddUser = this.User.Identity.Name,
                    HeadImage = string.IsNullOrEmpty(model.HeadImage) ? "" : model.HeadImage,
                    Introduction = model.Introduction,
                    NickName = model.NickName,
                    PassWord = model.PassWord,
                    RsState = 1,
                    RowVersion = 0
                };
   


                bool rv = op.InsertUsers(userModel);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 登录 8小时过期 过期后可以用老的token 来刷新token
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [WebApi.Common.Log]
        [Route("Login")]
        public JsonResult Login( [FromForm] WXQ.InOutPutEntites.Input.SystemManage.User.LoginInput model)
        {
            WXQ.BusinessCore.systemmanage.InitOp initOp = new WXQ.BusinessCore.systemmanage.InitOp();
     



            var a = this.Request;
           // WXQ.InOutPutEntites.Input.SystemManage.User.LoginInput model = new LoginInput();
            ResponseResult result = new ResponseResult();

            LoginInputModelValidation validator = new LoginInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp();

                WXQ.Enties.Users userModel = op.Login(model.UserName, model.PassWord);

                if (userModel != null && userModel.UsersId > 0)
                {
                    TokenModelJWT jwtUser = new TokenModelJWT
                    {
                        Uid = userModel.UsersId
                    };

                    result.Data = JwtHelper.SerializeJWT(jwtUser);
                }
                else
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }
  
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("ModifyUserPassord")]
        public JsonResult ModifyUserPassord([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.LoginInput model)
        {
            ResponseResult result = new ResponseResult();

            LoginInputModelValidation validator = new LoginInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(userId);

                WXQ.Enties.Users m = new WXQ.Enties.Users
                {
                    UsersId = this.User.Identity.Name.ToInt(0),
                    PassWord=model.PassWord
                };

                bool rv = op.ModifyUserPassord(m);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="token">用户token信息</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("RefreshToken")]
        public JsonResult RefreshToken([FromForm]  string token)
        {
            ResponseResult result = new ResponseResult();

            if (string.IsNullOrEmpty(token))
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add(ResponseResultMessageDefine.ParaErrorMessage);
            }
            else
            {
                TokenModelJWT tokenModel = JwtHelper.DerializeJWT(token);

                if (tokenModel.Uid > 0 && tokenModel.ExpDate > new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds())
                {
                    result.Data = JwtHelper.SerializeJWT(tokenModel);
                }
                else
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("ResetPassord")]
        public JsonResult ResetPassord([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.ResetPasswordInput model)
        {
            ResponseResult result = new ResponseResult();

            ResetPasswordInputModelValidation validator = new ResetPasswordInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(userId);

                WXQ.Enties.Users m = new WXQ.Enties.Users
                {
                    UsersId = model.UserId,
                };
                //默认密码
                string newPass = Appsettings.app(new string[] { "AppGlobeConfig", "DefaultPassord" });
                bool rv = op.ResetPassord(m, newPass);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
               
            }

            return Json(result);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("UpdateUsers")]
        public JsonResult UpdateUsers([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.UpdateInput model)
        {
            ResponseResult result = new ResponseResult();
           var  ts= this.Request.Form["HeadImage"];
            string dsf = ts;

            UpdateInputModelValidation validator = new UpdateInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(userId);
                WXQ.Enties.Users userModel = new WXQ.Enties.Users
                {
                    UsersId = model.UsersId,
                    UpdateDateTime = DateTime.Now,
                    UpdateUser = this.User.Identity.Name,
                    HeadImage = model.HeadImage.ToSafeString(),
                    Introduction = model.Introduction.ToSafeString(),
                    NickName = model.NickName,
                    PassWord = model.PassWord,
                };
    
                bool rv = op.UpdateUsers(userModel);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }



        /// <summary>
        /// 修改自己的信息
        /// </summary>
        /// <param name="model">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("common")]
        [WebApi.Common.Log]
        [Route("UpdateMyselfInfo")]
        public JsonResult UpdateMyselfInfo([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.UpdateInput model)
        {
            ResponseResult result = new ResponseResult();

            UpdateInputModelValidation validator = new UpdateInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp(userId);
                WXQ.Enties.Users userModel = new WXQ.Enties.Users
                {
                    UserName=model.UserName,
                    UsersId = userId,
                    UpdateDateTime = DateTime.Now,
                    UpdateUser = this.User.Identity.Name,
                    HeadImage = string.IsNullOrEmpty(model.HeadImage)?"0": model.HeadImage,
                    Introduction = model.Introduction,
                    NickName = model.NickName,
                    PassWord = model.PassWord,
                };
        
                bool rv = op.UpdateUsers(userModel);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }



        /// <summary>
        /// 获取用户集合，包含部门id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsersRefDepartment")]
        [WebApi.Common.Log]
        public JsonResult GetUsersRefDepartment([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.GetUsersRefDepartmentInput model)
        {
            ResponseResult result = new ResponseResult();

            GetUsersRefDepartmentInputModelValidation validator = new GetUsersRefDepartmentInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp();
                ListResult<object> rv = op.GetUsersRefDepartment(model.Name, model.departmentId, model.Page.PageSize, model.Page.PageIndex);

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
        /// 获取用户集合，包含角色id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetUsersRefRole")]
        [WebApi.Common.Log]
        public JsonResult GetUsersRefRole([FromForm]  WXQ.InOutPutEntites.Input.SystemManage.User.GetUsersRefRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            GetUsersRefRoleInputModelValidation validator = new GetUsersRefRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.UserOp op = new WXQ.BusinessCore.systemmanage.UserOp();
                ListResult<object> rv = op.GetUsersRefRole(model.Name, model.RoleId, model.Page.PageSize, model.Page.PageIndex);

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