using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_CreateFormOptions", "表单元素选项")]
    public   class CreateFormOptions : WXQ.Enties.DbModels.BaseModel
    {

        public CreateFormOptions()
        {


        }

        /// <summary>
        ///说明:
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "说明")] public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 字段名
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = false, ColumnDescription = "字段名")] public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// 类型
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = false, ColumnDescription = "类型")] public string ParaType { get; set; } = string.Empty;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
        public int OptionsId { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false, ColumnDescription = "是否必填")] public string IsRequired { get; set; } = string.Empty;



        /// <summary>
        /// 默认值
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false, ColumnDescription = "默认值")] public string DefaultValue { get; set; } = string.Empty;








    }
}
