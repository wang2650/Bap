using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///方法度量时间表
    ///</summary>
    [SugarTable("Tb_Metrics")]
    public partial class Metrics
    {
           public Metrics(){

            this.MethodName =Convert.ToString("");
            this.CreateDateTIme =DateTime.Now;
            this.CostTime =Convert.ToInt32("0");
            this.AppId =Convert.ToInt16("0");

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:方法名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MethodName {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDateTIme {get;set;}

           /// <summary>
           /// Desc:执行时长
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CostTime {get;set;}

           /// <summary>
           /// Desc:应用id
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public short AppId {get;set;}

    }
}
