using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("tb_limitip")]
    public partial class LimitIp
    {
           public LimitIp(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IpEnd {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public short? RelationType {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RelationId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IPBegin {get;set;}

    }
}
