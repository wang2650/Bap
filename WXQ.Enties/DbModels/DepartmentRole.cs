using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///部门角色关系
    ///</summary>
    [SugarTable("tb_departmentrole", "部门角色关系")]
    public partial class DepartmentRole: WXQ.Enties.DbModels.BaseModel
    {
           public DepartmentRole(){


           }
        /// <summary>
        /// 部门id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "部门id")] public int DepartmentId { get; set; } = -1;

    


           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int DepartmentRoleId {get;set;}



        /// <summary>
        ///角色id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "角色id")] public int RoleId { get; set; } = -1;

    }
}
