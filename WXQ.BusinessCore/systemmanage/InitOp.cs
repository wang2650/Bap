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
                result.Concat(CreateUser(result));

                #endregion
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
            WXQ.BusinessCore.systemmanage.UserOp op = new UserOp();
            WXQ.Enties.Users u = new Enties.Users();
            u.NickName = "超级管理员";
            u.UserName = "administrator";
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



    }
}