using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using WXQ.BusinessCore;
using WXQ.Enties.CommonObj;
using WXQ.InOutPutEntites.Input.SystemManage.Menu;
using WXQ.InOutPutEntites.Output;

namespace WebApi.Controllers.systemmanage
{
    /// <summary>
    /// 菜单模块
    /// </summary>

    [Route("Api/SystemManage/Menu")]
    [ApiController]
    public class MenuController : Controller
    {
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [WebApi.Common.Log]
        [Route("InsertMenu")]
        [Authorize("common")]
        public JsonResult InsertMenu([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.InsertMenuInput model)
        {
            ResponseResult result = new ResponseResult();

            InsertMenuInputModelValidation validator = new InsertMenuInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp(userId);

                WXQ.Enties.Menu r = new WXQ.Enties.Menu
                {
                    AddDateTime = DateTime.Now,
                    AddUser = this.User.Identity.Name,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    MenuName = model.MenuName,
                    MenuType = model.MenuType,
                    Url = model.Url
                };

                bool rv = op.InsertMenu(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="MenuId"></param>
        /// <returns></returns>
        [HttpGet]
        [WebApi.Common.Log]
        [Route("DeleteMenuByMenuId")]
        [Authorize("common")]
        public JsonResult DeleteMenuByMenuId([FromQuery]  int MenuId)
        {
            ResponseResult result = new ResponseResult();

            if (MenuId < 1)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("菜单id错误");
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp(userId);

                bool rv = op.DeleteMenuByMenuId(MenuId);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [WebApi.Common.Log]
        [Route("UpdateMenu")]
        [Authorize("common")]
        public JsonResult UpdateMenu([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.UpdateMenuInput model)
        {
            ResponseResult result = new ResponseResult();

            UpdateMenuInputModelValidation validator = new UpdateMenuInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp(userId);

                WXQ.Enties.Menu r = new WXQ.Enties.Menu
                {
                    Id = model.MenuId,
                    UpdateDateTime = DateTime.Now,
                    UpdateUser = this.User.Identity.Name,
                    Description = model.Description,
                    ParentId = model.ParentId,
                    MenuName = model.MenuName,
                    MenuType = model.MenuType,
                    Url = model.Url,
                };

                bool rv = op.UpdateMenu(r);

                if (!rv)
                {
                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 查找菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMenuList")]
        [WebApi.Common.Log]
        public JsonResult GetMenuList([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.GetMenuListInput model)
        {
            ResponseResult result = new ResponseResult();

            GetMenuListInputModelValidation validator = new GetMenuListInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Menu> rv = op.GetMenuList(model.MenuName, model.Url, model.ParentId,  pagemodel);

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
        /// 查找角色的菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMenuListByRoleId")]
        [WebApi.Common.Log]
        public JsonResult GetMenuListByRoleId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.GetMenuListByRoleIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetMenuListByRoleIdInputModelValidation validator = new GetMenuListByRoleIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Menu> rv = op.GetMenuListByRoleId(model.RoleId, pagemodel.PageIndex, pagemodel.PageSize);

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
        /// 获取用户的菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMenuListByUserId")]
        [WebApi.Common.Log]
        public JsonResult GetMenuListByUserId([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.GetMenuListByUserIdInput model)
        {
            ResponseResult result = new ResponseResult();

            GetMenuListByUserIdInputModelValidation validator = new GetMenuListByUserIdInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                SqlSugar.PageModel pagemodel = TypeAdapter.Adapt<WXQ.InOutPutEntites.Input.PageInput, SqlSugar.PageModel>(model.Page);
                ListResult<WXQ.Enties.Menu> rv = op.GetMenuListByUserId(model.UserId, pagemodel.PageIndex, pagemodel.PageSize);

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
        /// 获取当前用户的菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMenuTreeForCurrentUser")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetMenuTreeForCurrentUser()
        {
            ResponseResult result = new ResponseResult();


            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            if (userId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();



                ListResult<WXQ.Enties.CommonObj.MenuTree> rv = op.GetMenuTreeByUserId(userId);

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
/// 获取用户在某部门的权限，某角色的权限
/// </summary>
/// <param name="departmentId">部门id</param>
/// <param name="roleId">角色id</param>
/// <returns></returns>
        [HttpGet]
        [Route("GetMenuTreeForCurrentUserByDeparentId")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetMenuTreeForCurrentUserByDeparentId([FromQuery] int departmentId,[ FromQuery] int roleId)
        {
            ResponseResult result = new ResponseResult();


            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            if (userId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();


         
           
                    
                    
                    
                var allnodes=     op.GetMenuTreeByUserId(userId,departmentId);
                var  selectednodes= op.GetMenuListByRoleId(roleId,1,2000).Result.Select(m=>m.Id).ToList();

               

                if (allnodes == null )
                {

                    result.Code = ResponseResultMessageDefine.OpLost;
                    result.Errors.Add(ResponseResultMessageDefine.OpLostMessage);
                }
                else
                {
                    dynamic dy = new ExpandoObject();
                    dy.AllNodes = allnodes;
                    dy.SelectedNodes = selectednodes;
                    result.Data = dy;
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 获取用户的菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMenuTreeByUserId")]
        [WebApi.Common.Log]
        public JsonResult GetMenuTreeByUserId(int userId)
        {
            ResponseResult result = new ResponseResult();
       
            if (userId<=0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                ListResult<WXQ.Enties.CommonObj.MenuTree> rv = op.GetMenuTreeByUserId(userId);

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
        /// 获取用户可访问url地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUrlRightByUserId")]
        [WebApi.Common.Log]
        public JsonResult GetUrlRightByUserId([FromQuery] int userId)
        {
            ResponseResult result = new ResponseResult();

            if (userId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                List<string> rv = op.GetUrlRightByUserId(userId);

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
        /// 获取用户可访问url地址
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUrlRightForCurrentUser")]
        [WebApi.Common.Log]
        public JsonResult GetUrlRightForCurrentUser()
        {
            ResponseResult result = new ResponseResult();
            int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);

            if (userId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                List<string> rv = op.GetUrlRightByUserId(userId);

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
        /// 获取角色的菜单树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMenuTreeByRoleId")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult GetMenuTreeByRoleId(int roleId)
        {
            ResponseResult result = new ResponseResult();

            if (roleId <= 0)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors.Add("用户id错误");
            }
            else
            {
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp();

                ListResult<WXQ.Enties.CommonObj.MenuTree> rv = op.GetMenuTreeByRoleId(roleId);

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
        /// 设置角色的菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ModifyMentForRole")]
        [Authorize("common")]
        [WebApi.Common.Log]
        public JsonResult ModifyMentForRole([FromBody]  WXQ.InOutPutEntites.Input.SystemManage.Menu.ModifyMentForRoleInput model)
        {
            ResponseResult result = new ResponseResult();

            ModifyMentForRoleInputModelValidation validator = new ModifyMentForRoleInputModelValidation();
            ValidationResult vr = validator.Validate(model);

            if (!vr.IsValid)
            {
                result.Code = ResponseResultMessageDefine.ParaError;
                result.Errors = vr.Errors.Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                int userId = WebApi.Common.HelpOp.UserOp.GetUserId(this.User);
                WXQ.BusinessCore.systemmanage.MenuOp op = new WXQ.BusinessCore.systemmanage.MenuOp(userId);

                bool rv = op.ModifyMentForRole(model.RoleId, model.MenuIds);

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