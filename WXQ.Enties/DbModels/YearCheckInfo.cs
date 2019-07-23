using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_yearcheckinfo")]
    public partial class YearCheckInfo
    { /// <summary>
      /// 人员标识符
      /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 考核类别
        /// </summary>
        public string KHLB { set; get; }

        /// <summary>
        /// 考核年度
        /// </summary>
        public int KHND { set; get; }

        /// <summary>
        /// 考核结果
        /// </summary>
        public string KHJG { set; get; }

        /// <summary>
        /// 统计标识
        /// </summary>
        public int TJBS { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }

    }
}
