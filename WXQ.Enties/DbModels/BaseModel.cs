using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
   public class BaseModel
    {

        /// <summary>
        /// 添加时间
        /// </summary>
        [SugarColumn(IsNullable = false)] public DateTime AddDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(IsNullable = false)] public DateTime UpdateDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 添加人
        /// </summary>
        [SugarColumn(IsNullable = false)] public string AddUser { get; set; } = "";

        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(IsNullable = false)] public string UpdateUser { get; set; } = "";


        /// <summary>
        /// 记录状态
        /// </summary>
        [SugarColumn(IsNullable = false)] public byte RsState { get; set; } = 1;


        /// <summary>
        ///版本号
        /// </summary>
        [SugarColumn(IsNullable = false)] public int RowVersion { get; set; } = 0;



    }
}
