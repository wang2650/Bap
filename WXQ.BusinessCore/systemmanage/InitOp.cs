﻿using SqlSugar;
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
                PassWord = "12345678"//密码12345678
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
            if (op.InsertRole(role))
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

            int roleId = 0;

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
            WXQ.BusinessCore.systemmanage.RoleOp roleOp = new RoleOp(0);
            List<Enties.Role> roles = roleOp.GetRoleList();

            if (roles != null && roles.Count > 0)
            {
                roleId = roles[0].RoleId;

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
            }

            return returnvalue;
        }

        public bool CreateUserDepartment(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.DepartmentOp departmentOp = new DepartmentOp(0);

            int userId = 0;
            int departmentId = 0;
            bool returnvalue = true;
            ListResult<Enties.Department> departments = departmentOp.GetDepartmentList("", 0, 1, 10);
            if (departments.Result != null && departments.Result.Count > 0)
            {
                departmentId = departments.Result[0].DepartmentId;
            }
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

            return returnvalue;
        }

        public bool CreateRoleDepartment(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.DepartmentOp departmentOp = new DepartmentOp(0);

            int roleId = 0;
            int departmentId = 0;
            bool returnvalue = true;
            ListResult<Enties.Department> departments = departmentOp.GetDepartmentList("", 0, 1, 10);
            if (departments.Result != null && departments.Result.Count > 0)
            {
                departmentId = departments.Result[0].DepartmentId;
            }
            WXQ.BusinessCore.systemmanage.UserOp userOp = new UserOp(0);
            PageModel pageModel = new PageModel
            {
                PageIndex = 1,
                PageSize = 100
            };
            WXQ.BusinessCore.systemmanage.RoleOp roleOp = new RoleOp(0);
            List<Enties.Role> roles = roleOp.GetRoleList();

            if (roles != null && roles.Count > 0)
            {
                roleId = roles[0].RoleId;
            }

            #region 部门和用户关系

            DepartmentRoleManager departmentRoleManager = new DepartmentRoleManager();
            DepartmentRole dr = new DepartmentRole
            {
                RoleId = roleId,
                DepartmentId = departmentId
            };

            if (departmentRoleManager.Insert(dr))
            {
                result.Add("添加部门和角色关系成功");
            }
            else
            {
                result.Add("添加部门和角色关系失败");
            }

            #endregion 部门和用户关系

            return returnvalue;
        }

        public bool CreateRoleMenu(ref List<string> result)
        {
            WXQ.BusinessCore.systemmanage.RoleOp roleOp = new RoleOp(0);
            List<Enties.Role> roles = roleOp.GetRoleList();
            int roleId = 0;
            if (roles != null && roles.Count > 0)
            {
                roleId = roles[0].RoleId;
            }

            PageModel pageModel = new PageModel
            {
                PageIndex = 1,
                PageSize = 10000
            };

            #region 角色菜单关系

            WXQ.BusinessCore.systemmanage.MenuOp menuOp = new MenuOp(0);
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

            return true;
        }



        public bool CreateFormElementEvent()
        {
            WXQ.BusinessCore.CommonManager.DictOp op = new WXQ.BusinessCore.CommonManager.DictOp(0);
            bool rv = true;
            #region input
            WXQ.Enties.Dict r = new WXQ.Enties.Dict
            {

                Description = "",
                DictKey = "blur",
                DictValue = "模糊",
                DictType = "string",
                OrderBy = 0,
                GroupName = "hiddenevent",
                AddDateTime = DateTime.Now,
                AddUser = "0"
            };

            rv = rv && op.InsertDict(r);
            r.DictKey = "focus";
            r.DictKey = "获取焦点";
            r.GroupName = "hiddenevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "hiddenevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "clear";
            r.DictKey = "清空";
            r.GroupName = "hiddenevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region InputNumber
            r.DictKey = "focus";
            r.DictKey = "获取焦点";
            r.GroupName = "InputNumberevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "blur";
            r.DictKey = "模糊";
            r.GroupName = "InputNumberevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "InputNumberevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region  autoComplete
            r.DictKey = "select";
            r.DictKey = "选择";
            r.GroupName = "autoCompleteevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region radio
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "radioevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region checkbox
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "checkboxevent";
            rv = rv && op.InsertDict(r);
            #endregion


            #region  select
            r.DictKey = "change";
            r.DictKey = "选择";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "visible-change";
            r.DictKey = "下拉框出现/隐藏时触发";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);


            r.DictKey = "remove-tag";
            r.DictKey = "多选模式下移除tag时触发";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);


            r.DictKey = "clear";
            r.DictKey = "可清空的单选模式下用户点击清空按钮时触发";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "blur";
            r.DictKey = "模糊";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "focus";
            r.DictKey = "焦点";
            r.GroupName = "selectevent";
            rv = rv && op.InsertDict(r);


            #endregion



            #region switch
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "switchevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region cascader
            r.DictKey = "change";
            r.DictKey = "选择";
            r.GroupName = "cascaderevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "active-item-change";
            r.DictKey = "当父级选项变化时触发的事件，仅在 change-on-select 为 false 时可用";
            r.GroupName = "cascaderevent";
            rv = rv && op.InsertDict(r);




            r.DictKey = "visible-change";
            r.DictKey = "下拉框出现/隐藏时触发";
            r.GroupName = "cascaderevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "blur";
            r.DictKey = "模糊";
            r.GroupName = "cascaderevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "focus";
            r.DictKey = "焦点";
            r.GroupName = "cascaderevent";
            rv = rv && op.InsertDict(r);
            #endregion

            #region DatePicker
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "DatePickerevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "blur";
            r.DictKey = "模糊";
            r.GroupName = "DatePickerevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "focus";
            r.DictKey = "焦点";
            r.GroupName = "DatePickerevent";
            rv = rv && op.InsertDict(r);



            #endregion


            #region TimePicker
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "TimePickerevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "blur";
            r.DictKey = "模糊";
            r.GroupName = "TimePickerevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "focus";
            r.DictKey = "焦点";
            r.GroupName = "TimePickerevent";
            rv = rv && op.InsertDict(r);



            #endregion


            #region ColorPicker
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "ColorPickerevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "active-change";
            r.DictKey = "面板中当前显示的颜色发生改变时触发";
            r.GroupName = "ColorPickerevent";
            rv = rv && op.InsertDict(r);

            #endregion


            #region rate
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "rateevent";
            rv = rv && op.InsertDict(r);
            #endregion
            #region slider
            r.DictKey = "change";
            r.DictKey = "值改变";
            r.GroupName = "sliderevent";
            rv = rv && op.InsertDict(r);
            #endregion



            #region tree
            r.DictKey = "node-click";
            r.DictKey = "节点被点击时的回调";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-contextmenu";
            r.DictKey = "当某一节点被鼠标右键点击时会触发该事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "check-change";
            r.DictKey = "节点选中状态发生变化时的回调";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);




            r.DictKey = "check";
            r.DictKey = "当复选框被点击的时候触发";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "current-change";
            r.DictKey = "当前选中节点变化时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-expand";
            r.DictKey = "节点被展开时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);


            r.DictKey = "node-collapse";
            r.DictKey = "节点被关闭时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-drag-start";
            r.DictKey = "节点开始拖拽时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-drag-enter";
            r.DictKey = "拖拽进入其他节点时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "node-drag-leave";
            r.DictKey = "拖拽离开某个节点时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-drag-over";
            r.DictKey = "在拖拽节点时触发的事件（类似浏览器的 mouseover 事件）";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "node-drag-end";
            r.DictKey = "拖拽结束时（可能未成功）触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);
            r.DictKey = "node-drop";
            r.DictKey = "拖拽成功完成时触发的事件";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);

            r.DictKey = "check-change";
            r.DictKey = "节点选中状态发生变化时的回调";
            r.GroupName = "treeevent";
            rv = rv && op.InsertDict(r);


            #endregion





            return rv;
        }





    }
}