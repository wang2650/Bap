using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_rankinfo")]
    public partial class RankInfo
    { /// <summary>
      /// 人员标识符
      /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 职位级别
        /// </summary>
        public string ZWJB { set; get; }

        /// <summary>
        /// 职级批准日期
        /// </summary>
        public string ZJPZRQ { set; get; }

        /// <summary>
        /// 职级批准机关名称补充
        /// </summary>
        public string ZJPZJGMCBC { set; get; }

        /// <summary>
        /// 职级批准机关名称
        /// </summary>
        public string ZJPZJGMC { set; get; }

        /// <summary>
        /// 职级批准文号
        /// </summary>
        public string ZJPZWH { set; get; }

        /// <summary>
        /// 职级状态
        /// </summary>
        public string ZJZT { set; get; }

        /// <summary>
        /// 职级终止日期
        /// </summary>
        public string ZJZZRQ { set; get; }

        /// <summary>
        /// 职级批准时所在机构名称
        /// </summary>
        public string ZJPZSZJGMC { set; get; }

        /// <summary>
        /// 职级待遇批准时的职务
        /// </summary>
        public string ZJDYPZSDZW { set; get; }

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
