using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///日志
    ///</summary>
    [SugarTable("tb_nlog", "日志")]
    public partial class nlog : WXQ.Enties.DbModels.BaseModel
    {
           public nlog(){


           }
        /// <summary>
        ///记录日期
        /// </summary>           
        [SugarColumn( IsNullable = false   ,ColumnDescription = "记录日期")] public DateTime Logged { get; set; } = DateTime.Now;

        /// <summary>
        /// 日志级别:
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "日志级别")] public string Level {get;set;} = string.Empty;

        /// <summary>
        ///消息内容:
        /// </summary>           
        [SugarColumn(Length = 2000, IsNullable = false   ,ColumnDescription = "消息内容")] public string Message {get;set;} = string.Empty;

        /// <summary>
        /// 日志名
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "日志名")] public string Logger {get;set;} = string.Empty;

        /// <summary>
        /// 调用网站
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "调用网站")] public string CallSite {get;set;} = string.Empty;

        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int NlogId {get;set;}

        /// <summary>
        /// 应用名
        /// </summary>           
        [SugarColumn(Length = 100, IsNullable = false   ,ColumnDescription = "应用名")] public string Application {get;set;} = string.Empty;

    }
}
