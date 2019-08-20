using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.BusinessCore.BaseCore;
using WXQ.Enties;
namespace WXQ.BusinessCore.systemmanage
{
    public class InitOp : OpBase
    {
        public InitOp(int opUserId = 0) : base(opUserId)
        {
            base.OpUserId = opUserId;
        }

        public bool CreateTable(ref List<string> result)
        {
            DatabaseManager dbManager = new DatabaseManager();
            try
            {
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
            }
            catch (Exception ex)
            {
                result.Add("创建表错误" + ex.Message);
            }
            return true;
        }

        public bool DeleteTableData()
        {
            bool result = true;
            UsersManager UsersManager = new UsersManager();

            UsersManager.Db.Deleteable<WXQ.Enties.Users>().Where(u => u.UsersId > -1).ExecuteCommand();
            DepartmentManager departmentManager = new DepartmentManager();

            departmentManager.Db.Deleteable<WXQ.Enties.Department>().Where(um => um.DepartmentId > -1).ExecuteCommand();

            RoleManager roleManager = new RoleManager();

            roleManager.Db.Deleteable<WXQ.Enties.Role>().Where(um => um.RoleId > -1).ExecuteCommand();

            MenuManager menuManager = new MenuManager();

            menuManager.Db.Deleteable<WXQ.Enties.Menu>().Where(um => um.MenuId > -1).ExecuteCommand();

            UserRoleManager userRoleManager = new UserRoleManager();

            userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(d => d.RoleId > -1).ExecuteCommand();

            RoleMenuManager roleMenuManager = new RoleMenuManager();

            roleMenuManager.Db.Deleteable<WXQ.Enties.RoleMenu>().Where(d => d.RoleId > -1).ExecuteCommand();

            DepartmentRoleManager departmentRoleManager = new DepartmentRoleManager();

            departmentRoleManager.Db.Deleteable<WXQ.Enties.DepartmentRole>().Where(d => d.RoleId > -1).ExecuteCommand();

            UserDepartmentManager userDepartmentManager = new UserDepartmentManager();
            userDepartmentManager.Db.Deleteable<WXQ.Enties.UserDepartment>().Where(d => d.UserId > -1).ExecuteCommand();

            return result;
        }

        public bool CreateUser(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.UserOp op = new UserOp(0);

            WXQ.Enties.Users u = new Enties.Users
            {
                NickName = "超级管理员",
                UserName = "administrator",
                Introduction = "这是一个超级管理员账号，不要删除",
                Password = "12345678"//密码12345678
            };
            bool returnvalue = op.InsertUsers(u);
            if (returnvalue)
            {
                result.Add("添加管理员成功");
            }
            else
            {
                result.Add("添加管理员失败");
            }

            return returnvalue;
        }

        public bool CreateDepartment(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.DepartmentOp op = new DepartmentOp(0);
            WXQ.Enties.Department department = new Enties.Department
            {
                ParentId = 0,
                DepartmentName = "总公司",
                Description = "部门或组织的根"
            };
            bool returnvalue = op.InsertDepartment(department);
            if (returnvalue)
            {
                result.Add("添加部门成功");
            }
            else
            {
                result.Add("添加部门失败");
            }

            return returnvalue;
        }

        public bool CreateRole(ref List<string> result)
        {
      
            WXQ.BusinessCore.systemmanage.RoleOp op = new RoleOp(0);
            WXQ.Enties.Role role = new Enties.Role
            {
                RoleName = "系统管理员",
                Description = "超级管理员角色"
            };
            bool returnvalue = true;
            if ( op.InsertRole(role))
            {
                result.Add("添加角色成功");
            }
            else
            {
                returnvalue = false;
                result.Add("添加角色失败");
            }

            return returnvalue;
        }

        public bool CreateMenu(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.MenuOp menuOp = new MenuOp(0);
            bool returnValue = true;
            int menuId = 0;

            #region 系统首页

            WXQ.Enties.Menu sysindexMenu = new Enties.Menu
            {
                Icon = "el-icon-menu",
                MenuName = "系统首页",
                ParentId = 0,
                Url = "dashboard",
                MenuType = 1
            };
            menuId = menuOp.InsertMenuReturnId(sysindexMenu);
            if (menuId > 0)
            {
             
                result.Add("添加菜单系统首页成功");
            }
            else
            {
                result.Add("添加菜单系统首页失败");
            }

            #endregion 系统首页

            #region 系统管理

            WXQ.Enties.Menu sysmanagerMenu = new Enties.Menu
            {
                Icon = "el-icon-menu",
                MenuName = "系统管理",
                ParentId = 0,
                Url = "",
                MenuType = 1
            };
            menuId = menuOp.InsertMenuReturnId(sysmanagerMenu);
            if (menuId > 0)
            {
            
                result.Add("添加菜单系统管理成功");
                int sysmanagerId = menuId;

                #region 用户

                WXQ.Enties.Menu sysuserMenu = new Enties.Menu
                {
                    Icon = "el-icon-menu",
                    MenuName = "用户",
                    ParentId = sysmanagerId,
                    Url = "",
                    MenuType = 1
                };
                int usermenuId = menuOp.InsertMenuReturnId(sysuserMenu);
                if (usermenuId > 0)
                {
                    result.Add("添加菜单用户成功");

                    #region 用户管理

                    WXQ.Enties.Menu usermanageMenu = new Enties.Menu
                    {
                        Icon = "el-icon-menu",
                        MenuName = "用户管理",
                        ParentId = usermenuId,
                        Url = "usermanage",
                        MenuType = 1
                    };
                    if (menuOp.InsertMenuReturnId(usermanageMenu) > 0)
                    {
                        result.Add("添加菜单用户管理成功");
                    }
                    else
                    {
                        result.Add("添加菜单用户管理失败");
                    }

                    #endregion 用户管理
                }
                else
                {
                    result.Add("添加菜单用户失败");
                }

                #endregion 用户

                #region 角色

                WXQ.Enties.Menu sysroleMenu = new Enties.Menu
                {
                    Icon = "el-icon-menu",
                    MenuName = "角色管理",
                    ParentId = sysmanagerId,
                    Url = "",
                    MenuType = 1
                };
                int rolemenuId = menuOp.InsertMenuReturnId(sysroleMenu);
                if (rolemenuId > 0)
                {
                    result.Add("添加菜单角色管理成功");

                    #region 用户管理

                    WXQ.Enties.Menu rolemanageMenu = new Enties.Menu
                    {
                        Icon = "el-icon-menu",
                        MenuName = "角色",
                        ParentId = rolemenuId,
                        Url = "rolemanage",
                        MenuType = 1
                    };
                    if (menuOp.InsertMenuReturnId(rolemanageMenu) > 0)
                    {
                        result.Add("添加菜单角色成功");
                    }
                    else
                    {
                        result.Add("添加菜单角色失败");
                    }

                    #endregion 用户管理
                }
                else
                {
                    result.Add("添加菜单角色管理失败");
                }

                #endregion 角色

                #region 部门

                WXQ.Enties.Menu departmentmanageMenu = new Enties.Menu
                {
                    Icon = "el-icon-menu",
                    MenuName = "部门管理",
                    ParentId = sysmanagerId,
                    Url = "",
                    MenuType = 1
                };
                int departmentmanagermenuId = menuOp.InsertMenuReturnId(departmentmanageMenu);
                if (departmentmanagermenuId > 0)
                {
                    result.Add("添加菜单部门管理成功");

                    #region 用户管理

                    WXQ.Enties.Menu departmentMenu = new Enties.Menu
                    {
                        Icon = "el-icon-menu",
                        MenuName = "部门",
                        ParentId = departmentmanagermenuId,
                        Url = "departmentmanage",
                        MenuType = 1
                    };
                    if (menuOp.InsertMenuReturnId(departmentMenu) > 0)
                    {
                        result.Add("添加菜单部门成功");
                    }
                    else
                    {
                        result.Add("添加菜单部门失败");
                    }

                    #endregion 用户管理
                }
                else
                {
                    result.Add("添加菜单部门管理失败");
                }

                #endregion 部门
            }
            else
            {
                result.Add("添加菜单系统首页失败");
            }

            #endregion 系统管理

            #region 我的首页

            WXQ.Enties.Menu myindexMenu = new Enties.Menu
            {
                Icon = "el-icon-menu",
                MenuName = "我的首页",
                ParentId = 0,
                Url = "myselfinfo",
                MenuType = 1
            };
            menuId = menuOp.InsertMenuReturnId(myindexMenu);
            if (menuId > 0)
            {
               
                result.Add("添加菜单我的首页成功");
            }
            else
            {
                result.Add("添加菜单我的首页失败");
            }

            #endregion 我的首页

            if (returnValue)
            {
                result.Add("添加菜单成功");
            }
            else
            {
                result.Add("添加菜单失败");
            }

            return returnValue;
        }

        /// <summary>
        /// 创建关系
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool CreateRef(ref List<string> result)
        {
            bool returnvalue = true;
            int userId = 0;
            int departmentId = 0;
            int roleId = 0;
            WXQ.BusinessCore.systemmanage.MenuOp menuOp = new MenuOp(0);
            WXQ.BusinessCore.systemmanage.DepartmentOp departmentOp = new DepartmentOp(0);

            WXQ.BusinessCore.systemmanage.RoleOp roleOp = new RoleOp(0);

            WXQ.BusinessCore.systemmanage.UserOp userOp = new UserOp(0);
            PageModel pageModel = new PageModel
            {
                PageIndex = 1,
                PageSize = 100
            };
            ListResult<Enties.Users> users = userOp.GetUserList("", pageModel);
            if (users.Result != null && users.Result.Count > 0)
            {
                userId = users.Result[0].UsersId;
            }

            List<Enties.Role> roles = roleOp.GetRoleList();

            if (roles!= null && roles.Count > 0)
            {
                roleId = roles[0].RoleId;
            }

            ListResult<Enties.Department> departments = departmentOp.GetDepartmentList("", 0, 1, 10);
            if (departments.Result != null && departments.Result.Count > 0)
            {
                departmentId = departments.Result[0].DepartmentId;
            }

            #region 角色和部门关系

            DepartmentRoleManager departmentRoleManager = new DepartmentRoleManager();
            WXQ.Enties.DepartmentRole departmentRole = new Enties.DepartmentRole
            {
                RoleId = roleId,
                DepartmentId = departmentId,
                AddUser = "0"
            };



            if (departmentRoleManager.Insert(departmentRole))
            {
                result.Add("添加角色部门关系成功");
            }
            else
            {
                result.Add("添加角色部门关系失败");
            }

            #endregion 角色和部门关系

            #region 角色和用户关系

            if (roleOp.AddUserForRole(roleId, userId))
            {
                result.Add("添加角色和用户关系成功");
            }
            else
            {
                result.Add("添加角色和用户关系失败");
            }

            #endregion 角色和用户关系

            #region 部门和用户关系

            List<int> userIds = new List<int>
            {
                userId
            };
            if (departmentOp.AddUserForDepartment(departmentId, userIds))
            {
                result.Add("添加部门和用户关系成功");
            }
            else
            {
                result.Add("添加部门和用户关系失败");
            }

            #endregion 部门和用户关系

            #region 角色菜单关系

            ListResult<Enties.Menu> menus = menuOp.GetMenuList("", "", -1, pageModel);
            if (menus != null && menus.Result.Count > 0)
            {
                List<int> menuids = menus.Result.Select(m => m.MenuId).ToList();

                if (menuOp.ModifyMentForRole(roleId, menuids))
                {
                    result.Add("添加角色菜单关系成功");
                }
                else
                {
                    result.Add("添加角色菜单关系失败");
                }
            }

            #endregion 角色菜单关系

            return returnvalue;
        }
    }
}