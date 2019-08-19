using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///方法度量值
    ///</summary>
    [SugarTable("tb_metrics", "方法度量值")]
    public partial class Metrics : WXQ.Enties.DbModels.BaseModel
    {
           public Metrics(){


           }

        /// <summary>
        /// 消耗时间
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "消耗时间")] public int CostTime { get; set; } = -1;

        /// <summary>
        /// 应用id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "应用id")] public short AppId {get;set; } = -1;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int MetricsId {get;set;}

        /// <summary>
        /// 方法名
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "方法名")] public string MethodName {get;set;} = string.Empty;

    }
}
