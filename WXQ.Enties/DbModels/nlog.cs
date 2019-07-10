using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///nlog日志表
    ///</summary>
    [SugarTable("Tb_nlog")]
    public partial class nlog
    {
           public nlog(){

            this.Logged =DateTime.Now;

           }
           /// <summary>
           /// Desc:id主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:应用名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Application {get;set;}

           /// <summary>
           /// Desc:创建日期
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime Logged {get;set;}

           /// <summary>
           /// Desc:日志级别
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Level {get;set;}

           /// <summary>
           /// Desc:日志内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Message {get;set;}

           /// <summary>
           /// Desc:日志名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Logger {get;set;}

           /// <summary>
           /// Desc:调用位置
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CallSite {get;set;}

    }
}
