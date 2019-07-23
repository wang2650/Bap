using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_experienceinfo")]
    public partial class ExperienceInfo
    {


        [SugarColumn(IsPrimaryKey = true)]
        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 经历综述说明
        /// </summary>
        public string JLZSSM { set; get; }

        /// <summary>
        /// 经历综述
        /// </summary>
        public string JLZS { set; get; }

        /// <summary>
        /// 任职综述
        /// </summary>
        public string RZZS { set; get; }





    }
}
