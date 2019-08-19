using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///字典
    ///</summary>
    [SugarTable("tb_dict", "字典")]
    public partial class Dict : WXQ.Enties.DbModels.BaseModel
    {
           public Dict(){


           }
        /// <summary>
        /// 字典值
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "字典值")] public string DictValue { get; set; } = string.Empty;

        /// <summary>
        ///分组
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "分组")] public string GroupName {get;set; } = string.Empty;

        /// <summary>
        /// 数据类型
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "数据类型")] public string DictType {get;set; } = string.Empty;



        /// <summary>
        ///排序
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "排序")] public short OrderBy { get; set; } = 0;

      
           /// <summary>
           /// 主键
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int DictId {get;set;}


        /// <summary>
        /// 字典key
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "字典key")] public string DictKey {get;set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "描述")] public string Description {get;set; } = string.Empty;

    }
}
