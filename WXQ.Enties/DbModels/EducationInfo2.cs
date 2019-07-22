using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{


    

    [SugarTable("tb_educationinfo2")]
    public partial class EducationInfo2
    {

        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 学历名称
        /// </summary>
        public string XLMC { set; get; }

        /// <summary>
        /// 入学日期
        /// </summary>
        public string RXRQ { set; get; }

        /// <summary>
        /// 毕（肄）业日期
        /// </summary>
        public string BYRQ { set; get; }

        /// <summary>
        /// 学制（年）
        /// </summary>
        public string XZ { set; get; }

        /// <summary>
        /// 学校（单位）名称
        /// </summary>
        public string XXMC { set; get; }

        /// <summary>
        /// 学校（单位）所在政区
        /// </summary>
        public string XXSZZQ { set; get; }

        /// <summary>
        /// 从学单位类别
        /// </summary>
        public string CXDWLB { set; get; }

        /// <summary>
        /// 所学专业名称
        /// </summary>
        public string SXZYMC { set; get; }

        /// <summary>
        /// 所学专业类别
        /// </summary>
        public string SXZYLB { set; get; }

        /// <summary>
        /// 学习完成情况
        /// </summary>
        public string XXWCQK { set; get; }

        /// <summary>
        /// 学历补充
        /// </summary>
        public string XLBC { set; get; }

        /// <summary>
        /// 学历信息统计标识
        /// </summary>
        public int XLXXTJBS { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }

        /// <summary>
        /// 学历级别
        /// </summary>
        public string XLJB { set; get; }

        /// <summary>
        /// 教育类别
        /// </summary>
        public string JYLB { set; get; }

        /// <summary>
        /// 组织计划培训
        /// </summary>
        public int ZZJHPX { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }


    }
}
