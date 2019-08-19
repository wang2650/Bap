using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///页面元素
    ///</summary>
    [SugarTable("tb_menupageelement", "页面元素")]
    public partial class MenuPageElement : WXQ.Enties.DbModels.BaseModel
    {
           public MenuPageElement(){


           }
        /// <summary>
        /// 页面元素名称
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "页面元素名称")] public string ElementName {get;set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "描述")] public string Description {get;set; } = string.Empty;

       
           /// <summary>
           ///主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int MenuPageElementId {get;set;}


        /// <summary>
        /// 菜单id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "菜单id")] public int MenuId { get; set; } = -1;


    }
}
