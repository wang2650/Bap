using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using WXQ.InOutPutEntites.Output.SystemManage.User;
namespace WXQ.BusinessCore.systemmanage
{
    public class UserOp:OpBase
    {
 
        public UserOp(int opUserId=0) : base(opUserId)
        {
            base.OpUserId = opUserId;

        }


        /// <summary>
        /// 生成密码的种子
        /// </summary>
        private readonly string passwordRndSeed = "wangxiaoqiandluxiuliandfuyingandgonglindanandsongyanandchengyingxiu";

        /// <summary>
        /// 根据主键获取记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public WXQ.Enties.Users GetUserByUserId(int userId)
        {
            UsersManager UsersManager = new UsersManager();

            return UsersManager.GetById(userId);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool InsertUsers(WXQ.Enties.Users m)
        {
            UsersManager UsersManager = new UsersManager();
            m.AddUser = this.OpUserId.ToString();
            m.PassWord = CommonLib.Helpers.Encrypt.Sha256(passwordRndSeed + m.PassWord);

            int userId=  UsersManager.InsertReturnInt(m);

            return userId>0;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateUsers(WXQ.Enties.Users m)
        {
           
            UsersManager UsersManager = new UsersManager();

            m.RowVersion = m.RowVersion + 1;
            m.UpdateUser = this.OpUserId.ToString();

            return UsersManager.Db.Updateable<WXQ.Enties.Users>(m).SetColumns(it => new WXQ.Enties.Users()
            {
                HeadImage = m.HeadImage,
                Introduction = m.Introduction
               ,
                NickName = m.NickName,
                UpdateDateTime = DateTime.Now,
                UpdateUser = m.UpdateUser,
                RowVersion = m.RowVersion
            })
                .Where(u => u.UsersId == m.UsersId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool ModifyUserPassord(WXQ.Enties.Users m)
        {
            UsersManager UsersManager = new UsersManager();
            m.UpdateUser = this.OpUserId.ToString();
            m.PassWord = CommonLib.Helpers.Encrypt.Sha256(passwordRndSeed + m.PassWord);
            m.RowVersion = m.RowVersion + 1;
            return UsersManager.Db.Updateable<WXQ.Enties.Users>(m).SetColumns(it => new WXQ.Enties.Users()
            {
                PassWord = m.PassWord,
                UpdateDateTime = DateTime.Now,
                UpdateUser = m.UpdateUser,
                RowVersion = m.RowVersion
            })
                .Where(u => u.UsersId == m.UsersId).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="m"></param>
        /// <param name="newPass">新密码 (空为自动生成，并返回。不为空，则使用传入的密码)</param>
        /// <returns></returns>
        public bool ResetPassord(WXQ.Enties.Users m,string newPass)
        {
            UsersManager UsersManager = new UsersManager();
         
            newPass = string.IsNullOrEmpty(newPass) ? CommonLib.Randoms.GuidRandomGenerator.Instance.Generate().Substring(0, 8) : newPass;
            m.PassWord = CommonLib.Helpers.Encrypt.Sha256(passwordRndSeed + newPass);
            m.RowVersion = m.RowVersion + 1;
            m.UpdateUser = this.OpUserId.ToString();
            bool rv = UsersManager.Db.Updateable<WXQ.Enties.Users>(m).SetColumns(it => new WXQ.Enties.Users()
            {
                PassWord = m.PassWord,
                UpdateDateTime = DateTime.Now,
                UpdateUser = m.UpdateUser,
                RowVersion = m.RowVersion
            })
                .Where(u => u.UsersId == m.UsersId).ExecuteCommand() > 0;

            return rv;
        }

        /// <summary>
        /// 修改用户记录状态
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public bool UpdateUsersState(WXQ.Enties.Users m)
        {
            UsersManager UsersManager = new UsersManager();

            return UsersManager.Db.Updateable<WXQ.Enties.Users>(m).SetColumns(it => new WXQ.Enties.Users()
            {
                UpdateDateTime = DateTime.Now,
                UpdateUser = m.UpdateUser,
                RowVersion = m.RowVersion + 1,
                RsState = m.RsState
            })
                .Where(u => u.UsersId == m.UsersId).ExecuteCommand() > 0;
        }


    

        /// <summary>
        /// 删除用户根据主键
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="isLogicalDelete">是否逻辑删除</param>
        /// <returns></returns>
        public bool DeleteUsersByUsersId(int userId,bool isLogicalDelete=false)
        {
            UsersManager UsersManager = new UsersManager();

            RoleOp roleOp = new RoleOp();
            // 删除人和角色关系
            roleOp.DeleteRoleRefByUserId(userId);


            DepartmentOp departmentOp = new DepartmentOp();
            //部门中移除该人
            departmentOp.DeleteUserForDepartment(userId);

            return ReomveUserFormDb(userId, isLogicalDelete, UsersManager);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="isLogicalDelete">是否逻辑删除</param>
        /// <param name="UsersManager"></param>
        /// <returns></returns>
        private bool ReomveUserFormDb(int userId, bool isLogicalDelete, UsersManager UsersManager)
        {
            //删除人

            if (isLogicalDelete)
            {
                WXQ.Enties.Users user = new Enties.Users();
                user.RsState = 1;

                return UpdateUsersState(user);
            }
            else
            {
                return UsersManager.DeleteById(userId);
            }
        }

        /// <summary>
        /// 根据主键批量删除用户
        /// </summary>
        /// <param name="userIds">用户id</param>
        /// <param name="isLogicalDelete">是否逻辑删除</param>
        /// <returns></returns>
        public bool DeleteUsers(List<int> userIds, bool isLogicalDelete )
        {
            bool result = true;
            UsersManager UsersManager = new UsersManager();
            RoleOp roleOp = new RoleOp();
            List<dynamic> ids = new List<dynamic>();
            DepartmentOp departmentOp = new DepartmentOp();
            foreach (int id in userIds)
            {

                // 删除人和角色关系
                result= result&& roleOp.DeleteRoleRefByUserId(id);
                ///人和部门
                result = result && departmentOp.DeleteUserForDepartment(id);
                //删除自己
                result = result && ReomveUserFormDb(id, isLogicalDelete, UsersManager);
            }
            return result;


        }

     

        public ListResult<WXQ.Enties.Users> GetUserList(string userName, PageModel pageModel, int rsState = 1)
        {
            UsersManager UsersManager = new UsersManager();
            ListResult<WXQ.Enties.Users> result = new ListResult<Enties.Users>();

            System.Linq.Expressions.Expression<Func<Enties.Users, bool>> express = Expressionable.Create<WXQ.Enties.Users>()
                          .AndIF(!string.IsNullOrEmpty(userName), m => SqlFunc.Contains(m.NickName, userName) || SqlFunc.Contains(m.UserName, userName))
                          .AndIF(rsState > 1, it => it.RsState == rsState).ToExpression();//拼接表达式
            result.Result = UsersManager.GetPageList(express, pageModel);
            foreach (Enties.Users u in result.Result)
            {
                u.PassWord = "";
            }
            result.PageSize = pageModel.PageSize;
            result.PageIndex = pageModel.PageIndex;
            result.Total = pageModel.PageCount;
            return result;
        }








        
        /// <summary>
        /// 根据用户id批量获取用户
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public List<WXQ.Enties.Users> GetUserList(int[] userIds)
        {
            UsersManager UsersManager = new UsersManager();

            List<Enties.Users> result = UsersManager.GetList(u => userIds.Contains(u.UsersId));
            foreach (Enties.Users u in result)
            {
                u.PassWord = "";
            }

            return result;
        }

        /// <summary>
        /// 获取用户集合，包含部门id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ListResult<object> GetUsersRefDepartment(string name, int departmentId, int pageSize, int pageIndex)
        {
            ListResult<object> result = new ListResult<object>
            {
                Result = new List<object>()
            };
            int totalRs = 0;
            MenuManager MenuManager = new MenuManager();
            ISugarQueryable<Enties.Users> u1 = MenuManager.Db.Queryable<Enties.Users>().WhereIF(!string.IsNullOrEmpty(name), u => SqlFunc.Contains(u.NickName, name) || SqlFunc.Contains(u.UserName, name));

            ISugarQueryable<Enties.UserDepartment> ud1 = MenuManager.Db.Queryable<Enties.UserDepartment>().Where(ud => ud.DepartmentId == departmentId);
            var lt = MenuManager.Db.Queryable(u1, ud1, JoinType.Left, (j1, j2) => j1.UsersId == j2.UserId).OrderBy((j1, j2) => j2.DepartmentId, OrderByType.Desc).Select((j1, j2) => new { j1.UsersId, j1.UserName, j1.NickName, j2.DepartmentId }).ToPageList(pageIndex, pageSize, ref totalRs);
            if (totalRs > 0)
            {
                result.Result = new List<object>();
                foreach (var u in lt)
                {
                    result.Result.Add(u);
                }
            }

            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;

            return result;
        }

        /// <summary>
        /// 获取用户集合，包含角色id
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="roleId">角色id</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <returns></returns>
        public ListResult<object> GetUsersRefRole(string name, int roleId, int pageSize, int pageIndex)
        {
            ListResult<object> result = new ListResult<object>
            {
                Result = new List<object>()
            };
            int totalRs = 0;
            MenuManager MenuManager = new MenuManager();
            ISugarQueryable<Enties.Users> u1 = MenuManager.Db.Queryable<Enties.Users>().WhereIF(!string.IsNullOrEmpty(name), u => SqlFunc.Contains(u.NickName, name) || SqlFunc.Contains(u.UserName, name));

            ISugarQueryable<Enties.UserRole> ud1 = MenuManager.Db.Queryable<Enties.UserRole>().Where(ud => ud.RoleId == roleId);
            var lt = MenuManager.Db.Queryable(u1, ud1, JoinType.Left, (j1, j2) => j1.UsersId == j2.UserId).OrderBy((j1, j2) => j2.RoleId, OrderByType.Desc).Select((j1, j2) => new { j1.UsersId, j1.UserName, j1.NickName, j2.RoleId }).ToPageList(pageIndex, pageSize, ref totalRs);
            if (totalRs > 0)
            {
                result.Result = new List<object>();
                foreach (var u in lt)
                {
                    result.Result.Add(u);
                }
            }

            result.PageSize = pageSize;
            result.PageIndex = pageIndex;
            result.Total = totalRs;

            return result;
        }







        /// <summary>
        /// 登录  如果返回为null或者 用户id为0则失败
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public WXQ.Enties.Users Login(string userName, string password)
        {
            UsersManager UsersManager = new UsersManager();
            string EncryptPassword = CommonLib.Helpers.Encrypt.Sha256(passwordRndSeed + password);

            return UsersManager.UsersDb.GetSingle(u => u.UserName == userName && u.PassWord == EncryptPassword&& u.RsState==CommonLib.Tools.EnumHelper.GetValue<WXQ.Enties.CommonObj.RsState>( WXQ.Enties.CommonObj.RsState.Normal));
        }
    }
}