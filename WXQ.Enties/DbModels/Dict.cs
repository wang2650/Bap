using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///字典表
    ///</summary>
    [SugarTable("Tb_Dict")]
    public partial class Dict
    {
           public Dict(){

            this.DictKey =Convert.ToString("");
            this.DictValue =Convert.ToString("");
            this.DictType =Convert.ToString("");
            this.CreateTime =DateTime.Now;
            this.OrderBy =Convert.ToInt16("0");
            this.CreateUser =Convert.ToString("");
            this.UpdateTime =DateTime.Now;
            this.UpdateUser =Convert.ToString("");
            this.Description =Convert.ToString("");
            this.GroupName =Convert.ToString("");

           }
           /// <summary>
           /// Desc:id
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int Id {get;set;}

           /// <summary>
           /// Desc:字典的key
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DictKey {get;set;}

           /// <summary>
           /// Desc:字典的值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DictValue {get;set;}

           /// <summary>
           /// Desc:字典类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DictType {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? CreateTime {get;set;}

           /// <summary>
           /// Desc:排序
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public short? OrderBy {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CreateUser {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:DateTime.Now
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateTime {get;set;}

           /// <summary>
           /// Desc:更新人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string UpdateUser {get;set;}

           /// <summary>
           /// Desc:描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Description {get;set;}

           /// <summary>
           /// Desc:分组组名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GroupName {get;set;}

    }
}
