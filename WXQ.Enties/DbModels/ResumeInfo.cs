using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_resumeinfo")]
    public partial class ResumeInfo
    {  /// <summary>
       /// 人员标识符
       /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public string QSRQ { set; get; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public string JZRQ { set; get; }

        /// <summary>
        /// 所在单位及身份（职务)
        /// </summary>
        public string SZDWJSF { set; get; }

        /// <summary>
        /// 所在单位所在政区
        /// </summary>
        public string SZDWSZZQ { set; get; }

        /// <summary>
        /// 身份或职务
        /// </summary>
        public string SFHZW { set; get; }

        /// <summary>
        /// 职务级别
        /// </summary>
        public string ZWJB { set; get; }

        /// <summary>
        /// 履历类别
        /// </summary>
        public string LLJB { set; get; }

        /// <summary>
        /// 履历补充
        /// </summary>
        public string LLBC { set; get; }

        /// <summary>
        /// 履历补充（非正式学历）
        /// </summary>
        public string LLBCFZSXL { set; get; }

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
