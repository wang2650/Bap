using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///用户部门表
    ///</summary>
    [SugarTable("tb_userdepartment", "用户部门表")]
    public partial class UserDepartment : WXQ.Enties.DbModels.BaseModel
    {
           public UserDepartment(){


           }
        /// <summary>
        /// 部门id
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnDescription = "部门id")] public int DepartmentId { get; set; } = -1;

       
           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity= true, ColumnDescription = "主键")]
           public int UserDepartmentId {get;set;}


        /// <summary>
        /// 用户id
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnDescription = "用户id")] public int UserId {get;set;} = -1;

    }
}
