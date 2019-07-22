using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_degreeinfo")]
    public partial class DegreeInfo
    {

     
        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 学位
        /// </summary>
        public string XW { set; get; }

        /// <summary>
        /// 学位学习时间
        /// </summary>
        public string XWXXSJ { set; get; }

        /// <summary>
        /// 学位授予日期
        /// </summary>
        public string XWSYRQ { set; get; }

        /// <summary>
        /// 学位授予单位
        /// </summary>
        public string XWSYDW { set; get; }

        /// <summary>
        /// 学位授予单位所在政区
        /// </summary>
        public string XWSYDWSZZQ { set; get; }

        /// <summary>
        /// 统计标识
        /// </summary>
        public int TJBS { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }

        /// <summary>
        /// 学位级别
        /// </summary>
        public string XWJB { set; get; }

        /// <summary>
        /// 教育方式
        /// </summary>
        public string JYFS { set; get; }

        /// <summary>
        /// 学位主次序号
        /// </summary>
        public int XWZCXH { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }










    }
}
