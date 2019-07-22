using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_professionalskill")]
    public partial class ProfessionalSkill
    {  /// <summary>
       /// 人员标识符
       /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 专业技术任职资格（职称）
        /// </summary>
        public string ZYJSRZZG { set; get; }

        /// <summary>
        /// 获得资格日期
        /// </summary>
        public string HDZGRQ { set; get; }

        /// <summary>
        /// 获得资格途径
        /// </summary>
        public string HDZGTJ { set; get; }

        /// <summary>
        /// 评委会或考试名称
        /// </summary>
        public string PWHHKSMC { set; get; }

        /// <summary>
        /// 职称级别
        /// </summary>
        public string ZCJB { set; get; }

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
