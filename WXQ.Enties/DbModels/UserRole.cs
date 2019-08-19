using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    /// 用户角色表
    ///</summary>
    [SugarTable("tb_userrole", "用户角色表")]
    public partial class UserRole : WXQ.Enties.DbModels.BaseModel
    {
           public UserRole(){


           }
        /// <summary>
        /// 用户id
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnDescription = "用户id")] public int UserId { get; set; } = 1;

           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity= true, ColumnDescription = "主键")]
           public int UserRoleId {get;set;}


        /// <summary>
        ///角色id
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnDescription = "角色id")] public int RoleId { get; set; } = -1;

    }
}
