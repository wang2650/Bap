using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    /// ip地址限制
    ///</summary>
    [SugarTable("tb_limitip", "ip地址限制")]
    public partial class LimitIp : WXQ.Enties.DbModels.BaseModel
    {
           public LimitIp(){


           }
        /// <summary>
        /// 截止ip
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false   ,ColumnDescription = "截止ip")] public string IpEnd {get;set; } = string.Empty;


        /// <summary>
        /// 主键
        /// </summary>           
        [SugarColumn(IsPrimaryKey=true,IsIdentity=true   ,ColumnDescription = "主键")]
           public int LimitId {get;set;}

        /// <summary>
        /// 起始ip
        /// </summary>           
        [SugarColumn(Length = 50, IsNullable = false   ,ColumnDescription = "起始ip")] public string IPBegin {get;set; } = string.Empty;

    }
}
