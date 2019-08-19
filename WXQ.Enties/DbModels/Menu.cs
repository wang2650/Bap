using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///菜单
    ///</summary>
    [SugarTable("tb_menu", "菜单")]
    public partial class Menu : WXQ.Enties.DbModels.BaseModel
    {
           public Menu(){


           }
        /// <summary>
        /// 描述
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = false   ,ColumnDescription = "描述")] public string Description {get;set; } = string.Empty;

        /// <summary>
        /// 地址
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = false   ,ColumnDescription = "地址")] public string Url {get;set; } = string.Empty;

        /// <summary>
        /// 父id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "父id")] public int ParentId { get; set; } = -1;


        /// <summary>
        /// 图标
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = false   ,ColumnDescription = "图标")] public string Icon {get;set; } = string.Empty;



        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int MenuId {get;set;}


        /// <summary>
        /// 菜单名称
        /// </summary>           
        [SugarColumn(Length = 200, IsNullable = false   ,ColumnDescription = "菜单名称")] public string MenuName {get;set; } = string.Empty;

        /// <summary>
        /// 菜单类型
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "菜单类型")] public byte MenuType {get;set; } = 1;

    }
}
