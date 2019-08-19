using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore.BaseCore;

namespace WXQ.BusinessCore.systemmanage
{
    public class InitOp : OpBase
    {
        public InitOp(int opUserId = 0) : base(opUserId)
        {
            base.OpUserId = opUserId;
        }

        public List<string> InitSql()
        {
            List<string> result = new List<string>();

            try
            {
                #region 创建表
                result.Concat(CreateTable(result));


                #endregion
                //创建用户
                result.Concat(CreateUser(result));

                //创建部门
                result.Concat(CreateDepartment(result));
                // 创建角色
                result.Concat(CreateRole(result));
                // 创建菜单
                result.Concat(CreateMenu(result));

                // 创建关联关系
                result.Concat(CreateRef(result));
                

            }
            catch (Exception ex)
            {
                result.Add(ex.Message);
            }

            return result;
        }

        private List<string> CreateTable(List<string> result)
        {
            DatabaseManager dbManager = new DatabaseManager();
            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Department));
            result.Add("Department 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.DepartmentRole));
            result.Add("DepartmentRole 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Dict));
            result.Add("Dict 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.LimitIp));
            result.Add("LimitIp 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Menu));
            result.Add("Menu 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.MenuPageElement));
            result.Add("MenuPageElement 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Metrics));
            result.Add("Metrics 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.nlog));
            result.Add("nlog 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.OpLog));
            result.Add("OpLog 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Role));
            result.Add("Role 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.RoleMenu));
            result.Add("RoleMenu 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.UserDepartment));
            result.Add("UserDepartment 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.UserRole));
            result.Add("UserRole 创建完成");

            dbManager.Db.CodeFirst.InitTables(typeof(WXQ.Enties.Users));
            result.Add("Users 创建完成");

            return result;
        }

        private List<string> CreateUser(List<string> result)
        {
            WXQ.BusinessCore.systemmanage.UserOp op = new UserOp(0);
            WXQ.Enties.Users u = new Enties.Users();
            u.NickName = "超级管理员";
            u.UserName = "administrator";
            u.Introduction = "这是一个超级管理员账号，不要删除";
            u.Password = "e0662446dc3e1fe50801cae1b6e01b336263a9772cafe5abbf7ae677ae61c5e9";//密码12345678

           if (op.InsertUsers(u))
            {
                result.Add("添加管理员成功");
            }
            else
            {
                result.Add("添加管理员失败");
            }

            return result;
        }
        private List<string> CreateDepartment(List<string> result)
        {
            WXQ.BusinessCore.systemmanage.DepartmentOp op = new DepartmentOp(0);
            WXQ.Enties.Department department = new Enties.Department();
            department.ParentId = 0;
            department.DepartmentName = "总公司";
            department.Description = "部门或组织的根";

            if (op.InsertDepartment(department))
            {
                result.Add("添加部门成功");
            }
            else
            {
                result.Add("添加部门失败");
            }

            return result;
        }


        private List<string> CreateRole(List<string> result)
        {

            WXQ.BusinessCore.systemmanage.DepartmentOp departmentOp = new DepartmentOp(0);
            int departmentId = 0;
           var  lt= departmentOp.GetDepartmentList("总公司", 0, 1, 10);
            if (lt!=null&& lt.Result.Count>0)
            {
                departmentId = lt.Result[0].DepartmentId;
            }


            WXQ.BusinessCore.systemmanage.RoleOp op = new RoleOp(0);
            WXQ.Enties.Role role = new Enties.Role();
            role.RoleName = "系统管理员";
            role.Description = "超级管理员角色";

            if (departmentId>0&&op.InsertRole(role, departmentId))
            {
                result.Add("添加角色成功");
            }
            else
            {
                result.Add("添加角色失败或总公司不存在");
            }

            return result;
        }



        private List<string> CreateMenu(List<string> result)
        {

            WXQ.BusinessCore.systemmanage.MenuOp menuOp = new MenuOp(0);
            bool returnValue = true;
            int menuId = 0;
            #region  系统首页
            WXQ.Enties.Menu sysindexMenu = new Enties.Menu();
            sysindexMenu.Icon = "el-icon-menu";
            sysindexMenu.MenuName = "系统首页";
            sysindexMenu.ParentId = 0;
            sysindexMenu.Url = "dashboard";
            sysindexMenu.MenuType = 1;
            menuId = menuOp.InsertMenuReturnId(sysindexMenu);
            if (menuId > 0) {
                menuOp.InsertMenuReturnId(sysindexMenu);
                result.Add("添加菜单系统首页成功");
            }
            else
            {
                result.Add("添加菜单系统首页失败");
            }
            #endregion

            #region 系统管理
            WXQ.Enties.Menu sysmanagerMenu = new Enties.Menu();
            sysmanagerMenu.Icon = "el-icon-menu";
            sysmanagerMenu.MenuName = "系统管理";
            sysmanagerMenu.ParentId = 0;
            sysmanagerMenu.Url = "";
            sysmanagerMenu.MenuType = 1;
            menuId = menuOp.InsertMenuReturnId(sysmanagerMenu);
            if (menuId > 0)
            {
                menuOp.InsertMenuReturnId(sysindexMenu);
                result.Add("添加菜单系统管理成功");
                int sysmanagerId = menuId;
                #region  用户
                WXQ.Enties.Menu sysuserMenu = new Enties.Menu();
              
                sysuserMenu.Icon = "el-icon-menu";
                sysuserMenu.MenuName = "用户";
                sysuserMenu.ParentId = sysmanagerId;
                sysuserMenu.Url = "";
                sysuserMenu.MenuType = 1;
                int   usermenuId = menuOp.InsertMenuReturnId(sysuserMenu);
                if (usermenuId > 0)
                {
          
                    result.Add("添加菜单用户成功");

                    #region 用户管理
                    WXQ.Enties.Menu usermanageMenu = new Enties.Menu();

                    usermanageMenu.Icon = "el-icon-menu";
                    usermanageMenu.MenuName = "用户管理";
                    usermanageMenu.ParentId = usermenuId;
                    usermanageMenu.Url = "usermanage";
                    usermanageMenu.MenuType = 1;
                    if(menuOp.InsertMenuReturnId(usermanageMenu) >0)
                    {
                        result.Add("添加菜单用户管理成功");
                    }
                    else
                    {
                        result.Add("添加菜单用户管理失败");
                    }
                    #endregion


                }
                else
                {
                    result.Add("添加菜单用户失败");
                }

                #endregion

                #region  角色
                WXQ.Enties.Menu sysroleMenu = new Enties.Menu();

                sysroleMenu.Icon = "el-icon-menu";
                sysroleMenu.MenuName = "角色管理";
                sysroleMenu.ParentId = sysmanagerId;
                sysroleMenu.Url = "";
                sysroleMenu.MenuType = 1;
                int rolemenuId = menuOp.InsertMenuReturnId(sysroleMenu);
                if (rolemenuId > 0)
                {
                
                    result.Add("添加菜单角色管理成功");

                    #region 用户管理
                    WXQ.Enties.Menu rolemanageMenu = new Enties.Menu();

                    rolemanageMenu.Icon = "el-icon-menu";
                    rolemanageMenu.MenuName = "角色";
                    rolemanageMenu.ParentId = rolemenuId;
                    rolemanageMenu.Url = "rolemanage";
                    rolemanageMenu.MenuType = 1;
                    if (menuOp.InsertMenuReturnId(rolemanageMenu) > 0)
                    {
                        result.Add("添加菜单角色成功");
                    }
                    else
                    {
                        result.Add("添加菜单角色失败");
                    }
                    #endregion


                }
                else
                {
                    result.Add("添加菜单角色管理失败");
                }

                #endregion
                #region 部门
                WXQ.Enties.Menu departmentmanageMenu = new Enties.Menu();

                departmentmanageMenu.Icon = "el-icon-menu";
                departmentmanageMenu.MenuName = "部门管理";
                departmentmanageMenu.ParentId = sysmanagerId;
                departmentmanageMenu.Url = "";
                departmentmanageMenu.MenuType = 1;
                int departmentmanagermenuId = menuOp.InsertMenuReturnId(departmentmanageMenu);
                if (departmentmanagermenuId > 0)
                {

                    result.Add("添加菜单部门管理成功");

                    #region 用户管理
                    WXQ.Enties.Menu departmentMenu = new Enties.Menu();

                    departmentMenu.Icon = "el-icon-menu";
                    departmentMenu.MenuName = "部门";
                    departmentMenu.ParentId = departmentmanagermenuId;
                    departmentMenu.Url = "departmentmanage";
                    departmentMenu.MenuType = 1;
                    if (menuOp.InsertMenuReturnId(departmentMenu) > 0)
                    {
                        result.Add("添加菜单部门成功");
                    }
                    else
                    {
                        result.Add("添加菜单部门失败");
                    }
                    #endregion


                }
                else
                {
                    result.Add("添加菜单部门管理失败");
                }

                #endregion




            }
            else
            {
                result.Add("添加菜单系统首页失败");
            }



            #endregion 


            #region  我的首页

            WXQ.Enties.Menu myindexMenu = new Enties.Menu();
            myindexMenu.Icon = "el-icon-menu";
            myindexMenu.MenuName = "我的首页";
            myindexMenu.ParentId = 0;
            myindexMenu.Url = "myselfinfo";
            myindexMenu.MenuType = 1;
            menuId = menuOp.InsertMenuReturnId(myindexMenu);
            if (menuId > 0)
            {
                menuOp.InsertMenuReturnId(sysindexMenu);
                result.Add("添加菜单我的首页成功");
            }
            else
            {
                result.Add("添加菜单我的首页失败");
            }
            #endregion



            if (returnValue)
            {
                result.Add("添加菜单成功");
            }
            else
            {
                result.Add("添加菜单失败");
            }

            return result;
        }

        /// <summary>
        /// 创建关系
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private List<string> CreateRef(List<string> result)
        {

            int userId = 0;
            int departmentId = 0;
            WXQ.Enties.Role r = new Enties.Role();
            WXQ.BusinessCore.systemmanage.MenuOp menuOp = new MenuOp(0);
            WXQ.BusinessCore.systemmanage.DepartmentOp departmentOp = new DepartmentOp(0);

            WXQ.BusinessCore.systemmanage.RoleOp roleOp = new RoleOp(0);


            WXQ.BusinessCore.systemmanage.UserOp userOp = new UserOp(0);
            PageModel pageModel = new PageModel();
            pageModel.PageIndex = 1;
            pageModel.PageSize = 10;
            var users = userOp.GetUserList("", pageModel);
            if (users.Result!=null&& users.Result.Count>0)
            {
                userId = users.Result[0].UsersId;
            }

            var roles = roleOp.GetRoleList("", pageModel);

            if (roles.Result != null && roles.Result.Count > 0)
            {
                r = roles.Result[0];
            }


            var departments = departmentOp.GetDepartmentList("",0,1,10);
            if (departments.Result != null && departments.Result.Count > 0)
            {
                departmentId = departments.Result[0].DepartmentId;
            }

            #region  角色和部门关系

            if ( roleOp.InsertRole(r, departmentId))
            {
                result.Add("添加角色部门关系成功");
            }

            else
            {
                result.Add("添加角色部门关系失败");
            }
            #endregion

            #region  角色和用户关系
     
            if (roleOp.AddUserForRole(r.RoleId, userId))
            {
                result.Add("添加角色和用户关系成功");
            }

            else
            {
                result.Add("添加角色和用户关系失败");
            }
            #endregion
            #region  部门和用户关系

            List<int> userIds = new List<int>();
            userIds.Add(userId);
            if (departmentOp.AddUserForDepartment(departmentId, userIds))
            {
                result.Add("添加部门和用户关系成功");
            }

            else
            {
                result.Add("添加部门和用户关系失败");
            }
            #endregion

            #region 角色菜单关系
            var menus = menuOp.GetMenuList("", "", -1, pageModel);
            if (menus!=null&& menus.Result.Count>0)
            {
                var menuids = menus.Result.Select(m => m.MenuId).ToList();

                if(menuOp.ModifyMentForRole(r.RoleId, menuids))
                {
                    result.Add("添加角色菜单关系成功");
                }
                else
                {
                    result.Add("添加角色菜单关系失败");
                }
            }
            #endregion



            return result;
        }


    }
}