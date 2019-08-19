using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///用户
    ///</summary>
    [SugarTable("tb_users", "用户")]
    public partial class Users : WXQ.Enties.DbModels.BaseModel
    {
           public Users(){


           }
        /// <summary>
        /// 密码
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "密码")] public string Password {get;set;} = string.Empty;

        /// <summary>
        /// 头像
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "头像")] public string HeadImage {get;set;} = string.Empty;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity= true, ColumnDescription = "主键")]
           public int UsersId {get;set;}

        /// <summary>
        /// 介绍
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = false, ColumnDescription = "介绍")] public string Introduction {get;set;} = string.Empty;

        /// <summary>
        ///用户名
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = false, ColumnDescription = "用户名")] public string UserName {get;set;} = string.Empty;

        /// <summary>
        /// 昵称
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = false, ColumnDescription = "昵称")] public string NickName {get;set;} = string.Empty;

    }
}
