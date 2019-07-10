using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///用户表
    ///</summary>
    [SugarTable("Tb_Users")]
    public partial class Users
    {
           public Users(){

            this.AddDateTime =DateTime.Now;
            this.UpdateDateTime =DateTime.Now;
            this.AddUser =Convert.ToString("");
            this.UpdateUser =Convert.ToString("");
            this.RowVersion =Convert.ToInt32("0");
            this.Introduction =Convert.ToString("");
            this.NickName =Convert.ToString("");
            this.HeadImage =Convert.ToString("");
            this.RsState =Convert.ToByte("1");

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ID {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserName {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Password {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime AddDateTime {get;set;}

           /// <summary>
           /// Desc:修改时间
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateDateTime {get;set;}

           /// <summary>
           /// Desc:添加人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AddUser {get;set;}

           /// <summary>
           /// Desc:修改人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UpdateUser {get;set;}

           /// <summary>
           /// Desc:版本号
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int RowVersion {get;set;}

           /// <summary>
           /// Desc:介绍
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Introduction {get;set;}

           /// <summary>
           /// Desc:昵称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string NickName {get;set;}

           /// <summary>
           /// Desc:头像
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HeadImage {get;set;}

           /// <summary>
           /// Desc:
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public byte RsState {get;set;}

    }
}
