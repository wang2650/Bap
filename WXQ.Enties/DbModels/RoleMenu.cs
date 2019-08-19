using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///角色菜单关联
    ///</summary>
    [SugarTable("tb_rolemenu", "角色菜单关联")]
    public partial class RoleMenu : WXQ.Enties.DbModels.BaseModel
    {
           public RoleMenu(){


           }
        /// <summary>
        ///菜单id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "菜单id")] public int MenuId { get; set; } = -1;

         
     
           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity= true, ColumnDescription = "主键")]
           public int RoleMenuId {get;set;}

        /// <summary>
        ///角色id
        /// </summary>           
        [SugarColumn(IsNullable = false, ColumnDescription = "角色id")] public int RoleId { get; set; } = -1;

    }
}
