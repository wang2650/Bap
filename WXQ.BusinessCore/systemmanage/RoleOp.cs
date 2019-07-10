using SqlSugar;
using System;
using System.Collections.Generic;

namespace WXQ.BusinessCore.systemmanage
{
    public class RoleOp : OpBase
    {
        public RoleOp(int opUserId = 0) : base(opUserId)
        {
            base.OpUserId = opUserId;
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <param name="pageModel">分页</param>
        /// <param name="departmentId">部门Id</param>
        /// <param name="rsState">状态</param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Role> GetRoleList(string roleName, PageModel pageModel, int departmentId = -1, int rsState = 1)
        {
            RoleManager roleManager = new RoleManager();
            ListResult<WXQ.Enties.Role> result = new ListResult<Enties.Role>();
            int totalRs = 0;

            result.Result = roleManager.Db.Queryable<WXQ.Enties.DepartmentRole, WXQ.Enties.Role>((dr, r) => new object[] {
                    JoinType.Left,dr.RoleId==r.Id})
                  .Where((dr, r) => r.RsState == rsState && dr.DepartmentId == departmentId)
                  .WhereIF(!string.IsNullOrEmpty(roleName), (dr, r) => SqlFunc.Contains(r.RoleName, roleName))
                  .Select((dr, r) => r).ToPageList(pageModel.PageIndex, pageModel.PageSize, ref totalRs);

            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool InsertRole(WXQ.Enties.Role r, int departmentId)
        {
            RoleManager roleManager = new RoleManager();
            bool result = false;
            r.AddUser = this.OpUserId.ToString();
            int roleId = roleManager.InsertReturnInt(r);
            if (roleId > 0)
            {
                DepartmentRoleManager departmentRoleManager = new DepartmentRoleManager();
                WXQ.Enties.DepartmentRole departmentRole = new Enties.DepartmentRole
                {
                    RoleId = roleId,
                    DepartmentId = departmentId,
                    AddUser = this.OpUserId.ToString()
                };
                result = departmentRoleManager.Insert(departmentRole);
            }

            return result;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateRole(WXQ.Enties.Role r)
        {
            RoleManager roleManager = new RoleManager();
            r.UpdateUser = this.OpUserId.ToString();
            return roleManager.Db.Updateable(r).Where(m => m.Id == r.Id).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除角色根据主键
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteRoleByRoleId(int roleId)
        {
            RoleManager roleManager = new RoleManager();
            DepartmentRoleManager departmentRoleManager = new DepartmentRoleManager();

            /// 删除角色和人的关系
            DeleteRoleRefByRoleId(roleId);

            ///删除角色和部门的关系
            departmentRoleManager.Delete(d => d.RoleId == roleId);
            /// 删除角色
            return roleManager.DeleteById(roleId);
        }

        /// <summary>
        /// 查找用户所属的角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Role> GetRoleListByUserId(int userId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Role> result = new ListResult<Enties.Role>();

            int totalRs = 0;

            RoleManager roleManager = new RoleManager();
            result.Result = roleManager.Db.Queryable<WXQ.Enties.UserRole, WXQ.Enties.Role>((ur, r) => new object[] {
                    JoinType.Left,ur.RoleId==r.Id})
                    .Where((ur, r) => ur.UserId == userId)
                  .Select((ur, r) => r).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }

        /// <summary>
        /// 查找角色包含的用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Users> GetUsersListByRoleId(int roleId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Users> result = new ListResult<Enties.Users>();

            int totalRs = 0;

            RoleManager roleManager = new RoleManager();
            result.Result = roleManager.Db.Queryable<WXQ.Enties.UserRole, WXQ.Enties.Users>((ur, r) => new object[] {
                    JoinType.Left,ur.UserId==r.ID})
                    .Where((ur, r) => ur.RoleId == roleId)
                  .Select((ur, r) => r).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;

            foreach (Enties.Users u in result.Result)
            {
                u.Password = "";
            }

            return result;
        }

        /// <summary>
        /// 获取部门集合的所含的角色id集合
        /// </summary>
        /// <param name="departmentIds"></param>
        /// <returns></returns>

        public List<int> GetRoleIdsForDpartmentIds(List<int> departmentIds)
        {
            DepartmentManager DepartmentManager = new DepartmentManager();

            return DepartmentManager.Db.Queryable<Enties.DepartmentRole>().In(it => it.DepartmentId, departmentIds).Select(it => it.RoleId).ToList();
        }

        /// <summary>
        /// 移除角色集合中的人
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public bool DeleteUserByRoleIds(List<int> roleIds, int userId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(it => roleIds.Contains(it.RoleId) && it.UserId == userId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 获取当前部门和所有子部门的角色id集合
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public List<int> GetRolesForDepartmentAndSubDepartment(int departmentId)
        {
            DepartmentManager DepartmentManager = new DepartmentManager();
            DepartmentOp departmentOp = new DepartmentOp();

            List<int> departmentIds = departmentOp.GetDpartmentIsForCurrentAndAllNodes(departmentId, true);

            return GetRoleIdsForDpartmentIds(departmentIds);
        }

        /// <summary>
        /// 删除人和所有角色的关系
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteRoleRefByUserId(int userId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(it => it.UserId == userId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除角色下的所有人的关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteRoleRefByRoleId(int roleId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(it => it.RoleId == roleId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 从某角色中移除某用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RemoveUserFromRole(int userId, int roleId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(it => it.RoleId == roleId && it.UserId == userId).ExecuteCommand() > 0;
        }

        /// <summary>
        ///批量从某角色中移除某些用户
        /// </summary>
        /// <param name="userIds"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool RemoveUserFromRole(List<int> userIds, int roleId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Deleteable<WXQ.Enties.UserRole>().Where(it => it.RoleId == roleId && userIds.Contains(it.UserId)).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 角色是否存在某用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool UserExitInRole(int userId, int roleId)
        {
            UserRoleManager userRoleManager = new UserRoleManager();
            return userRoleManager.Db.Queryable<WXQ.Enties.UserRole>().Where(it => it.RoleId == roleId && it.UserId == userId).Count() > 0;
        }

        public bool AddUserForRole(int roleId, int userId)
        {
            List<int> userIds = new List<int>();
            userIds.Add(userId);
   
            return AddUserForRole(roleId, userIds);
        }

        /// <summary>
        /// 角色批量添加人员
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public bool AddUserForRole(int roleId, List<int> userIds)
        {
            bool result = true;
            UserRoleManager userRoleManager = new UserRoleManager();
            if (userIds != null && userIds.Count > 0)
            {
                List<WXQ.Enties.UserRole> lt = new List<Enties.UserRole>();
                DateTime dt = DateTime.Now;
                foreach (int m in userIds)
                {
                    if (!UserExitInRole(m, roleId))
                    {
                        WXQ.Enties.UserRole rm = new Enties.UserRole
                        {
                            UserId = m,
                            RoleId = roleId,
                            AddDateTime = dt,
                            AddUser = this.OpUserId.ToString()
                        };
                        lt.Add(rm);
                    }
                }

                result = result && userRoleManager.CurrentDb.InsertRange(lt);
            }

            return result;
        }
    }
}