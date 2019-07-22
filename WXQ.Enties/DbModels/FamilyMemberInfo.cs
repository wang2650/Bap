using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_familymemberinfo")]
    public partial class FamilyMemberInfo
    {



        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 人员姓名
        /// </summary>
        public string RYXM { set; get; }

        /// <summary>
        /// 人员与该人关系名称
        /// </summary>
        public string RYYGRGXMC { set; get; }

        /// <summary>
        /// 称 谓
        /// </summary>
        public string CW { set; get; }

        /// <summary>
        /// 人员出生日期
        /// </summary>
        public string RYCSRQ { set; get; }

        /// <summary>
        /// 人员工作单位名称补充
        /// </summary>
        public string RYGZDWMCBC { set; get; }

        /// <summary>
        /// 人员工作单位名称
        /// </summary>
        public string RYGZDWMC { set; get; }

        /// <summary>
        /// 人员工作单位所在政区
        /// </summary>
        public string RYGZDWSZZQ { set; get; }

        /// <summary>
        /// 人员国籍
        /// </summary>
        public string RYGJ { set; get; }

        /// <summary>
        /// 人员民族
        /// </summary>
        public string RYMZ { set; get; }

        /// <summary>
        /// 人员学历
        /// </summary>
        public string RYXL { set; get; }

        /// <summary>
        /// 人员政治面貌
        /// </summary>
        public string RYZZMM { set; get; }

        /// <summary>
        /// 人员身份
        /// </summary>
        public string RYSF { set; get; }

        /// <summary>
        /// 人员职务
        /// </summary>
        public string RYZW { set; get; }

        /// <summary>
        /// 人员职级
        /// </summary>
        public string RYZJ { set; get; }

        /// <summary>
        /// 人员现状
        /// </summary>
        public string RYXZ { set; get; }

        /// <summary>
        /// 人员备注
        /// </summary>
        public string RYBZ { set; get; }

        /// <summary>
        /// 序号
        /// </summary>
        public int XH { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string XB { set; get; }

        /// <summary>
        /// 统计标识
        /// </summary>
        public int TJBS { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string SFZHM { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }


    }
}
