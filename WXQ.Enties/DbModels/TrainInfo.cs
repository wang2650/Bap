using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_traininfo")]
    public partial class TrainInfo
    {
        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 培训类别
        /// </summary>
        public string PXLB { set; get; }

        /// <summary>
        /// 培训离岗状态
        /// </summary>
        public string PXLGZT { set; get; }

        /// <summary>
        /// 培训起始日期
        /// </summary>
        public string PXQSRQ { set; get; }

        /// <summary>
        /// 培训结束日期
        /// </summary>
        public string PXJSRQ { set; get; }

        /// <summary>
        /// 培训主办单位名称补充
        /// </summary>
        public string PXZBDWMCBC { set; get; }

        /// <summary>
        /// 培训主办单位名称
        /// </summary>
        public string PXZBDWMC { set; get; }

        /// <summary>
        /// 培训主办单位级别
        /// </summary>
        public string PXZBDWJB { set; get; }

        /// <summary>
        /// 从学单位名称补充
        /// </summary>
        public string CXDWMCBC { set; get; }

        /// <summary>
        /// 从学单位名称
        /// </summary>
        public string CXDWMC { set; get; }

        /// <summary>
        /// 从学单位所在政区
        /// </summary>
        public string CXDWSZZQ { set; get; }

        /// <summary>
        /// 从学单位类别
        /// </summary>
        public string CXDWLB { set; get; }

        /// <summary>
        /// 培训班名称
        /// </summary>
        public string PXBMC { set; get; }

        /// <summary>
        /// 培训班类别
        /// </summary>
        public string PXBLB { set; get; }

        /// <summary>
        /// 培训专业名称
        /// </summary>
        public string PXZYMC { set; get; }

        /// <summary>
        /// 培训专业类别
        /// </summary>
        public string PXZYLB { set; get; }

        /// <summary>
        /// 培训完成情况
        /// </summary>
        public string PXWCQK { set; get; }

        /// <summary>
        /// 统计标识
        /// </summary>
        public int TJBS { set; get; }

        /// <summary>
        /// 培训机构类别
        /// </summary>
        public string PXJGLB { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }

        /// <summary>
        /// 培训形式
        /// </summary>
        public string PXXS { set; get; }

        /// <summary>
        /// 出国培训境内学习天数
        /// </summary>
        public int CGPXJNXXTS { set; get; }

        /// <summary>
        /// 出国培训境外学习天数
        /// </summary>
        public int CGPXJWXXTS { set; get; }

        /// <summary>
        /// 考察实习项目
        /// </summary>
        public string KCSXXM { set; get; }

        /// <summary>
        /// 提供奖学金（经费赞助）单位
        /// </summary>
        public string TGJXJDW { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string BZ { set; get; }

        /// <summary>
        /// 组织（人事）部门认可
        /// </summary>
        public string ZZBMRK { set; get; }

        /// <summary>
        /// 培训情况说明
        /// </summary>
        public string PXQKSM { set; get; }

        /// <summary>
        /// 学时
        /// </summary>
        public string XS { set; get; }

        /// <summary>
        /// 考核情况
        /// </summary>
        public string KHQK { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }

    }
}
