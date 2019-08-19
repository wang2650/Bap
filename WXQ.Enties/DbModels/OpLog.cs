using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    /// 操作日志
    ///</summary>
    [SugarTable("tb_oplog", "操作日志")]
    public partial class OpLog : WXQ.Enties.DbModels.BaseModel
    {
           public OpLog(){


           }
        /// <summary>
        /// 控制器
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "控制器")] public string ControllerName {get;set;} = string.Empty;

        /// <summary>
        /// 创建日期
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "创建日期")] public DateTime CreateDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 操作者
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = "操作者")] public int OpUser { get; set; } = 0;

        /// <summary>
        ///参数
        /// </summary>           
        [SugarColumn(Length = 8000, IsNullable = false   ,ColumnDescription = "参数")] public string ParaValue {get;set;} = string.Empty;

        /// <summary>
        /// 应用id
        /// </summary>           
        [SugarColumn(IsNullable = false   ,ColumnDescription = " 应用id")] public short AppId { get; set; } = -1;

        /// <summary>
        /// ip
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "ip")] public string Ip {get;set;} = string.Empty;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int OpLogId {get;set;}

        /// <summary>
        /// 浏览器
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "浏览器")] public string Brower {get;set;} = string.Empty;

        /// <summary>
        /// 方法名
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "方法名")] public string MethodName {get;set;} = string.Empty;

        /// <summary>
        ///导航
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "导航")] public string navigator {get;set;} = string.Empty;

    }
}
