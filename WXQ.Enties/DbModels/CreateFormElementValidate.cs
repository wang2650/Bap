using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_CreateFormElementValidate", "表单元素检验")]
  public  class CreateFormElementValidate : WXQ.Enties.DbModels.BaseModel
    {


        public CreateFormElementValidate()
        {


        }

        /// <summary>
        ///说明:
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "说明")] public string Remark { get; set; } = string.Empty;

        /// <summary>
        /// 参数
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false, ColumnDescription = "参数名")] public string Para { get; set; } = string.Empty;

        /// <summary>
        /// 类型
        /// </summary>           
        [SugarColumn(Length = 20, IsNullable = false, ColumnDescription = "类型")] public string ParaType { get; set; } = string.Empty;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
        public int ValidateId { get; set; }

    

        /// <summary>
        /// 默认值
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false, ColumnDescription = "默认值")] public string DefaultValue { get; set; } = string.Empty;














    }
}
