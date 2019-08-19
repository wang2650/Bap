using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WXQ.BusinessCore.systemmanage
{
    public class DepartmentOp:OpBase
    {
        public DepartmentOp(int opUserId=0) : base(opUserId)
        {
            base.OpUserId = opUserId;

        }



        /// <summary>
        /// 根据部门id批量删除部门
        /// </summary>
        /// <param name="departmentIds"></param>
        /// <returns></returns>
        public bool DeleteDepartment(List<int> departmentIds)
        {
            DepartmentManager DepartmentManager = new DepartmentManager();
            List<dynamic> ids = new List<dynamic>();
            foreach (int id in departmentIds)
            {
                ids.Add(id);
            }

            return DepartmentManager.DeleteByIds(ids.ToArray());
        }

        /// <summary>
        /// 删除部门根据主键
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool DeleteDepartmentByDepartmentId(int departmentId)
        {
            bool result = true;
            RoleOp roleOp = new RoleOp();
            List<int> roleIds = roleOp.GetRolesForDepartmentAndSubDepartment(departmentId);

            if (roleIds != null && roleIds.Count > 0)
            {
                foreach (int id in roleIds)
                {
                    // 删除角色
                    result = result && roleOp.DeleteRoleByRoleId(id);
                }
            }

            //当前和所有子层级的部门id
            List<int> departmentIds = GetDpartmentIsForCurrentAndAllNodes(departmentId, true);

            if (departmentIds != null && departmentIds.Count > 0)
            {
                DepartmentManager DepartmentManager = new DepartmentManager();
                UserDepartmentManager userDepartmentManager = new UserDepartmentManager();
                foreach (int id in departmentIds)
                {
                    ///删除部门中的用户
                    result = result && userDepartmentManager.Delete(d => d.DepartmentId == departmentId);
                    ///删除部门
                    result = result && DepartmentManager.DeleteById(departmentId);
                }
            }

            return result;
        }

        public ListResult<WXQ.Enties.Department> GetDepartmentList(string departmentName, int parentId, int pageIndex, int pageSize, int rsState = 1)
        {
            int totalRs = 0;
            DepartmentManager DepartmentManager = new DepartmentManager();
            ListResult<WXQ.Enties.Department> result = new ListResult<Enties.Department>
            {
                Result = DepartmentManager.Db.Queryable<Enties.Department>().WhereIF(!string.IsNullOrEmpty(departmentName), m => SqlFunc.Contains(m.DepartmentName, departmentName))
                    .WhereIF(parentId > -1, it => it.ParentId == parentId)
                    .WhereIF(rsState > 1, it => it.RsState == rsState)
                   .ToPageList(pageIndex, pageSize, ref totalRs),

                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = totalRs
            };
            return result;
        }

        /// <summary>
        /// 查找部门
        /// </summary>
        /// <param name="departmentName">部门名</param>
        /// <param name="parentId">上一级id</param>
        /// <param name="pageModel">分页</param>
        /// <param name="rsState">记录状态</param>
        /// <returns></returns>
        /// <summary>
        /// 查找用户所在的部门
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Department> GetDepartmentListByUserId(int userId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Department> result = new ListResult<Enties.Department>();

            int totalRs = 0;

            DepartmentManager DepartmentManager = new DepartmentManager();
            result.Result = DepartmentManager.Db.Queryable<WXQ.Enties.UserDepartment, WXQ.Enties.Department>((ud, d) => new object[] {
                    JoinType.Left,ud.DepartmentId==d.DepartmentId})
                    .Where((ud, d) => ud.UserId == userId)
                  .Select((ud, d) => d).ToPageList(pageIndex, pageSize, ref totalRs);
            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }

        /// <summary>
        /// 当前及下级的部门
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<WXQ.InOutPutEntites.Output.SystemManage.Department.NodeTree> GetDepartmentAndSubDepartmentByUserId(int userId, int pageIndex, int pageSize)
        {
            List<WXQ.InOutPutEntites.Output.SystemManage.Department.NodeTree> result = new List<WXQ.InOutPutEntites.Output.SystemManage.Department.NodeTree>();

            int totalRs = 0;

            DepartmentManager DepartmentManager = new DepartmentManager();
            List<Enties.Department> lt = DepartmentManager.Db.Queryable<WXQ.Enties.UserDepartment, WXQ.Enties.Department>((ud, d) => new object[] {
                    JoinType.Left,ud.DepartmentId==d.DepartmentId})
                    .Where((ud, d) => ud.UserId == userId)
                  .Select((ud, d) => d).ToPageList(pageIndex, pageSize, ref totalRs);

            if (lt != null && lt.Count > 0)
            {
                foreach (WXQ.Enties.Department d in lt)
                {
                    WXQ.InOutPutEntites.Output.SystemManage.Department.NodeTree nt = new InOutPutEntites.Output.SystemManage.Department.NodeTree
                    {
                        label = d.DepartmentName,
                        value = d.DepartmentId
                    };

                    ListResult<Enties.Department> subnodes = GetDepartmentList("", d.DepartmentId, 1, 1000);
                    if (subnodes != null && subnodes.Total > 0)
                    {
                        nt.children = new List<InOutPutEntites.Output.SystemManage.Department.NodeTree>();
                        foreach (WXQ.Enties.Department s in subnodes.Result)
                        {
                            WXQ.InOutPutEntites.Output.SystemManage.Department.NodeTree subnode = new InOutPutEntites.Output.SystemManage.Department.NodeTree
                            {
                                label = s.DepartmentName,
                                value = s.DepartmentId
                            };

                            nt.children.Add(subnode);
                        }
                    }
                    result.Add(nt);
                }
            }

            return result;
        }

        /// <summary>
        /// 查找部门的用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ListResult<WXQ.Enties.Users> GetUserListByDepartmentId(int departmentId, int pageIndex, int pageSize)
        {
            ListResult<WXQ.Enties.Users> result = new ListResult<Enties.Users>();

            int totalRs = 0;

            DepartmentManager DepartmentManager = new DepartmentManager();
            result.Result = DepartmentManager.Db.Queryable<WXQ.Enties.UserDepartment, WXQ.Enties.Users>((ud, d) => new object[] {
                    JoinType.Left,ud.UserId==d.UsersId})
                    .Where((ud, d) => ud.DepartmentId == departmentId)
                  .Select((ud, d) => d).ToPageList(pageIndex, pageSize, ref totalRs);
            foreach (Enties.Users u in result.Result)
            {
                u.Password = "";
            }

            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;
            return result;
        }

        /// <summary>
        /// 获取下属所有的子部门id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public List<int> GetDpartmentIsForCurrentAndAllNodes(int departmentId, bool IncludeSelf = false)
        {
            List<int> result = GetSubNodeDpartmentId(departmentId).Distinct().ToList();
            if (IncludeSelf)
            {
                result.Add(departmentId);
            }

            return result;
        }

        private List<int> GetSubNodeDpartmentId(int departmentId)
        {
            DepartmentManager DepartmentManager = new DepartmentManager();
            List<int> result = new List<int>();
            List<int> ltsub = DepartmentManager.Db.Queryable<Enties.Department>().WhereIF(departmentId > -1, it => it.ParentId == departmentId).Select(it => it.DepartmentId).ToList();
            if (ltsub != null && ltsub.Count > 0)
            {
                foreach (int d in ltsub)
                {
                    result.Union(GetSubNodeDpartmentId(d)).ToList();
                }

                result = result.Union(ltsub).ToList();
            }

            return result;
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertDepartment(WXQ.Enties.Department model)
        {
            model.AddUser = this.OpUserId.ToString();
            DepartmentManager DepartmentManager = new DepartmentManager();
            return DepartmentManager.Insert(model);
        }

        /// <summary>
        /// 部门是否有该用户
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public bool UserExitInDepartment(int userId, int departmentId)
        {
            UserDepartmentManager userDepartmentManager = new UserDepartmentManager();
            return userDepartmentManager.Db.Queryable<WXQ.Enties.UserDepartment>().Where(it => it.DepartmentId == departmentId && it.UserId == userId).Count() > 0;
        }

        /// <summary>
        /// 部门批量添加人员
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="userIds"></param>
        /// <param name="addUser"></param>
        /// <returns></returns>
        public bool AddUserForDepartment(int departmentId, List<int> userIds)
        {
            bool result = true;
            UserDepartmentManager userDepartmentManager = new UserDepartmentManager();
            if (userIds != null && userIds.Count > 0)
            {
                List<WXQ.Enties.UserDepartment> lt = new List<Enties.UserDepartment>();
                DateTime dt = DateTime.Now;
                foreach (int m in userIds)
                {
                    if (!UserExitInDepartment(m,departmentId))
                    {
                        WXQ.Enties.UserDepartment rm = new Enties.UserDepartment
                        {
                            UserId = m,
                            DepartmentId = departmentId,
                            AddDateTime = dt,
                            AddUser = this.OpUserId.ToString()
                        };
                        lt.Add(rm);
                    }
                   
                }
                DeleteUserForDepartment(departmentId, userIds);

                result = result && userDepartmentManager.CurrentDb.InsertRange(lt);
            }

            return result;
        }



        /// <summary>
        /// 部门批量移除人员
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="userIds"></param>
        /// <param name="addUser"></param>
        /// <returns></returns>
        public bool DeleteUserForDepartment(int departmentId, List<int> userIds)
        {
            bool result = false;
            UserDepartmentManager userDepartmentManager = new UserDepartmentManager();

            //包含自己和所有下级（包括孙子节点。。。。）的部门id
           List<int>  departmentsIncludeAllSub=   GetDpartmentIsForCurrentAndAllNodes(departmentId, true);

            //删除关系 包括所有下级部门中的该用户
            if (userIds != null && userIds.Count > 0)
            {
                result = userDepartmentManager.Delete(d => userIds.Contains(d.UserId) && departmentsIncludeAllSub.Contains( d.DepartmentId) );
            }

            ///删除部门中角色和人的关系
            RoleOp roleOp = new RoleOp();
            List<int> roleIds = roleOp.GetRolesForDepartmentAndSubDepartment(departmentId);

            if (userIds != null && userIds.Count > 0)
            {
                foreach (int id in userIds)
                {
                    roleOp.DeleteUserByRoleIds(roleIds, id);
                }
            }

            return result;
        }

        /// <summary>

        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateDepartment(WXQ.Enties.Department model)
        {
            DepartmentManager DepartmentManager = new DepartmentManager();
            model.UpdateUser = this.OpUserId.ToString();
            return DepartmentManager.Db.Updateable(model).Where(m => m.DepartmentId == model.DepartmentId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 从所有部门中移除人
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUserForDepartment(int userId)
        {
            UserDepartmentManager userDepartmentManager = new UserDepartmentManager();

            return userDepartmentManager.Delete(d => d.UserId == userId);
        }
    }
}