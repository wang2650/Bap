using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///角色
    ///</summary>
    [SugarTable("tb_role", "角色")]
    public partial class Role : WXQ.Enties.DbModels.BaseModel
    {
           public Role(){


           }
        /// <summary>
        /// 描述
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "描述")] public string Description {get;set; } = string.Empty;

        /// <summary>
        ///主键Id
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity= true, ColumnDescription = "主键Id")]
           public int RoleId {get;set;}


        /// <summary>
        /// 角色名
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "角色名")] public string RoleName {get;set; } = string.Empty;

    }
}
