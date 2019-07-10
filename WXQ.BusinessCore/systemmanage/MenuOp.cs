using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WXQ.BusinessCore.systemmanage
{
    public class MenuOp:OpBase
    {

        public MenuOp(int opUserId=0) : base(opUserId)
        {
            base.OpUserId = opUserId;

        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertMenu(WXQ.Enties.Menu model)
        {
            model.AddUser = this.OpUserId.ToString();
            MenuManager MenuManager = new MenuManager();

            return MenuManager.Insert(model);
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateMenu(WXQ.Enties.Menu model)
        {
            MenuManager MenuManager = new MenuManager();
            model.UpdateUser = this.OpUserId.ToString();
            return MenuManager.Db.Updateable(model).Where(m => m.Id == model.Id).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除菜单根据主键
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteMenuByMenuId(int menuId)
        {
            MenuManager MenuManager = new MenuManager();

            return MenuManager.DeleteById(menuId);
        }

        /// <summary>
        /// 根据主键批量删除菜单
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool DeleteMenus(List<int> menuIds)
        {
            MenuManager MenuManager = new MenuManager();
            List<dynamic> ids = new List<dynamic>();
            foreach (int id in menuIds)
            {
                ids.Add(id);
            }

            return MenuManager.DeleteByIds(ids.ToArray());
        }
        /// <summary>
        ///菜单list转树形
        /// </summary>
        /// <param name="menuList"></param>
        /// <param name="parentId"></param>
        /// <param name="orderIndex"></param>
        /// <returns></returns>
        public List<WXQ.Enties.CommonObj.MenuTree> GetMenuTree(List<WXQ.Enties.Menu> menuList, int parentId = 0, int orderIndex = 0)
        {
            List<WXQ.Enties.CommonObj.MenuTree> result = new List<WXQ.Enties.CommonObj.MenuTree>();

            if (menuList != null && menuList.Count > 0)
            {
                List<Enties.Menu> rootItems = menuList.Where(m => m.ParentId == parentId).ToList();
                if (rootItems != null && rootItems.Count > 0)
                {
                    for (int i = 0; i < rootItems.Count; i++)
                    {
                        WXQ.Enties.CommonObj.MenuTree menuTree = new Enties.CommonObj.MenuTree
                        {
                            icon = rootItems[i].Icon,
                            title = rootItems[i].MenuName,
                            subs = GetMenuTree(menuList, rootItems[i].Id, i)
                        };

                        if (menuTree.subs != null && menuTree.subs.Count > 0)
                        {
                            menuTree.index = orderIndex == 0 ? i.ToString() : orderIndex.ToString() + "-" + i.ToString();
                        }
                        else
                        {
                            menuTree.index = rootItems[i].Url;
                        }

                        result.Add(menuTree);
                    }
                }
            }

            return result;
        }

        public List<WXQ.Enties.CommonObj.TreeNode> GetNodeTree(List<WXQ.Enties.CommonObj.TreeNode> menuList, int parentId = 0, int orderIndex = 0)
        {
            List<WXQ.Enties.CommonObj.TreeNode> rootItems = menuList.Where(m => m.ParentId == parentId).ToList();

        
              
                if (rootItems != null && rootItems.Count > 0)
                {
                    for (int i = 0; i < rootItems.Count; i++)
                    {
                        rootItems[i].children = GetNodeTree(menuList, rootItems[i].id, i);

                    }

                }
            

            return rootItems;
        }

        /// <summary>
        /// 查找菜单
        /// </summary>
        /// <param name="menuName">菜单名</param>
        /// <param name="url">地址</param>
        /// <param name="pageModel">分页</param>
        /// <param name="rsState">记录状态</param>
        /// <returns></returns>

        public ListResult<WXQ.Enties.Menu> GetMenuList(string menuName, string url, int parentId, PageModel pageModel, int rsState = 1)
        {
            MenuManager MenuManager = new MenuManager();
            ListResult<WXQ.Enties.Menu> result = new ListResult<Enties.Menu>();

            System.Linq.Expressions.Expression<Func<Enties.Menu, bool>> express = Expressionable.Create<WXQ.Enties.Menu>()
                          .AndIF(!string.IsNullOrEmpty(menuName), m => SqlFunc.Contains(m.MenuName, menuName))
                          .AndIF(!string.IsNullOrEmpty(url), m => SqlFunc.Contains(m.Url, url))
                           .AndIF(parentId > -1, it => it.ParentId == parentId)
                          .AndIF(rsState > 1, it => it.RsState == rsState).ToExpression();//拼接表达式

            result.Result = MenuManager.GetPageList(express, pageModel);

            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }

        /// <summary>
        /// 查找角色包含的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Menu> GetMenuListByRoleId(int roleId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Menu> result = new ListResult<Enties.Menu>();

            int totalRs = 0;
            MenuManager MenuManager = new MenuManager();
            result.Result = MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Menu>((um, m) => new object[] {
                    JoinType.Left,um.MenuId==m.Id})
                    .Where((um, m) => um.RoleId == roleId)
                  .Select((um, m) => m).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }


        public ListResult<WXQ.Enties.CommonObj.MenuTree> GetMenuTreeByRoleId(int roleId)
        {
            ListResult<WXQ.Enties.CommonObj.MenuTree> result = new ListResult<WXQ.Enties.CommonObj.MenuTree>();


            MenuManager MenuManager = new MenuManager();
            var  rmQuery = MenuManager.Db.Queryable<WXQ.Enties.RoleMenu>().Where(rm=>rm.RoleId==roleId);
            
            var  menusQuery = MenuManager.Db.Queryable<WXQ.Enties.Menu>();

                
             var lt=   MenuManager.Db.Queryable(menusQuery, rmQuery, JoinType.Left, (m, rm) => m.Id == rm.MenuId&& rm.RoleId==roleId).Select((m, rm) => new  { m.Id, m.MenuName, m.Url, m.Icon, rm.RoleId  }).ToList();//left join

            if (lt!=null&&lt.Count>0)
            {
                List<WXQ.Enties.Menu> menuList = new List<Enties.Menu>();


                foreach (var  d in lt)
                {
                    WXQ.Enties.Menu m = new Enties.Menu();
                    m.Id = d.Id;
                    m.MenuName = d.MenuName;
                    m.Url = d.Url;
                    m.Icon = d.Icon;
                    menuList.Add(m);

                }
                result.Result = GetMenuTree(menuList, 0);
                result.Total = result.Result.Count;
                result.PageSize = result.Result.Count;
            }


            result.PageIndex = 1;
        
            return result;
        }




        /// <summary>
        /// 某用户的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Menu> GetMenuListByUserId(int userId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Menu> result = new ListResult<Enties.Menu>();

            int totalRs = 0;
            MenuManager MenuManager = new MenuManager();
            result.Result = MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Menu, WXQ.Enties.UserRole>((um, m, ur) => new object[] {
                    JoinType.Left,um.MenuId==m.Id,
                    JoinType.Left,um.RoleId==ur.RoleId
            })
                    .Where((um, m, ur) => ur.UserId == userId)
                  .Select((um, m) => m).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }
        /// <summary>
        /// 某用户的菜单树
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.CommonObj.MenuTree> GetMenuTreeByUserId(int userId)
        {
            ListResult<WXQ.Enties.CommonObj.MenuTree> result = new ListResult<WXQ.Enties.CommonObj.MenuTree>();


            MenuManager MenuManager = new MenuManager();
            result.Result = GetMenuTree( MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Menu, WXQ.Enties.UserRole>((um, m, ur) => new object[] {
                    JoinType.Left,um.MenuId==m.Id,
                    JoinType.Left,um.RoleId==ur.RoleId
            })
                    .Where((um, m, ur) => ur.UserId == userId&& m.MenuType==1)
                  .Select((um, m) => m).Distinct().ToList(),0);


            result.PageSize = result.Result.Count;
            result.PageIndex = 1;
            result.Total = result.Result.Count;
            return result;
        }
        /// <summary>
        /// 某用户的菜单树
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<WXQ.Enties.CommonObj.TreeNode> GetMenuTreeByUserId(int userId,int departmentId)
        {
            List<WXQ.Enties.CommonObj.TreeNode> result = new List<WXQ.Enties.CommonObj.TreeNode>();


            MenuManager MenuManager = new MenuManager();

            List<WXQ.Enties.Menu> lt = MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Menu, WXQ.Enties.UserRole, WXQ.Enties.DepartmentRole>((um, m, ur, dr) => new object[] {
                    JoinType.Left,um.MenuId==m.Id,
                    JoinType.Left,um.RoleId==ur.RoleId,
                    JoinType.Left,um.RoleId==dr.RoleId

            })
                    .Where((um, m, ur, dr) => ur.UserId == userId && m.MenuType == 1 && dr.DepartmentId == departmentId)
                  .Select((um, m) => m).ToList();

            if (lt!=null&& lt.Count>0)
            {
                foreach (var m in lt)
                {
                    WXQ.Enties.CommonObj.TreeNode n = new Enties.CommonObj.TreeNode();
                    n.id = m.Id;
                    n.label = m.MenuName;
                    n.ParentId = m.ParentId;
                    result.Add(n);
                }


            }




            return GetNodeTree(result, 0);


         
        }
        /// <summary>
        /// 获取用户可访问url地址  去掉/ 注意  前端比较的时候  /kuige/articles/7724786 将和kuigearticles7724786 比较。所以配置的url地址  不支持参数化
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetUrlRightByUserId(int userId)
        {
            List<string> result = new List<string>();

            MenuManager MenuManager = new MenuManager();
            result=MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Menu, WXQ.Enties.UserRole>((um, m, ur) => new object[] {
                    JoinType.Left,um.MenuId==m.Id,
                    JoinType.Left,um.RoleId==ur.RoleId
            })
                    .Where((um, m, ur) => ur.UserId == userId)
                  .Select((um, m) => m.Url.Trim().Replace("/","")).Distinct().ToList();

            return result;
        }




        /// <summary>
        /// 查找菜单所在的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Role> GetUsersListByRoleId(int menuId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Role> result = new ListResult<Enties.Role>();

            int totalRs = 0;
            MenuManager MenuManager = new MenuManager();
            result.Result = MenuManager.Db.Queryable<WXQ.Enties.RoleMenu, WXQ.Enties.Role>((um, m) => new object[] {
                    JoinType.Left,um.RoleId==m.Id})
                    .Where((um, m) => um.MenuId == menuId)
                  .Select((um, m) => m).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }

        /// <summary>
        /// 设置角色的菜单
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public bool ModifyMentForRole(int roleId, List<int> menuIds)
        {
            bool result = false;
            RoleMenuManager roleMenuManager = new RoleMenuManager();
            //先全删除关系
            result = roleMenuManager.Delete(d => d.RoleId == roleId);
            //添加关系
            if (menuIds != null && menuIds.Count > 0)
            {
                List<WXQ.Enties.RoleMenu> lt = new List<Enties.RoleMenu>();
                DateTime dt = DateTime.Now;
                foreach (int m in menuIds)
                {
                    WXQ.Enties.RoleMenu rm = new Enties.RoleMenu
                    {
                        RoleId = roleId,
                        MenuId = m,
                        AddDateTime = dt,
                        AddUser = this.OpUserId.ToString()
                    };
                    lt.Add(rm);
                }
                result = result && roleMenuManager.CurrentDb.InsertRange(lt);
            }

            return result;
        }
    }
}