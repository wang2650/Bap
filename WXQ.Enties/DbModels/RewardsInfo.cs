using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_rewardsinfo")]
    public partial class RewardsInfo
    { /// <summary>
      /// 人员标识符
      /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 奖惩类别
        /// </summary>
        public string JCLB { set; get; }

        /// <summary>
        /// 奖惩名称补充
        /// </summary>
        public string JCMCBC { set; get; }

        /// <summary>
        /// 奖惩名称
        /// </summary>
        public string JCMC { set; get; }

        /// <summary>
        /// 奖惩批准日期
        /// </summary>
        public string JCPZRQ { set; get; }

        /// <summary>
        /// 奖惩批准机关名称补充
        /// </summary>
        public string JCPZJGMCBC { set; get; }

        /// <summary>
        /// 奖惩批准机关名称
        /// </summary>
        public string JCPZJGMC { set; get; }

        /// <summary>
        /// 批准奖惩机关级别
        /// </summary>
        public string PZJCJGJB { set; get; }

        /// <summary>
        /// 奖惩时职务层次
        /// </summary>
        public string JCSZWCC { set; get; }

        /// <summary>
        /// 奖惩原因
        /// </summary>
        public string JCYY { set; get; }

        /// <summary>
        /// 奖惩说明
        /// </summary>
        public string JCSM { set; get; }

        /// <summary>
        /// 奖惩撤销日期
        /// </summary>
        public string JCCXRQ { set; get; }

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
