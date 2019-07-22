using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.DbModels
{
    /// <summary>
    /// 单位
    /// </summary>
    [SugarTable("tb_departmentinfo")]
    public partial class DepartmentInfo
    {

        [SugarColumn(IsPrimaryKey = true)]
        /// <summary>
        /// 人员标识符
        /// </summary>
        public string RYBSF { set; get; }

        /// <summary>
        /// 单位名称简拼
        /// </summary>
        public string DWMCJP { set; get; }

        /// <summary>
        /// 单位代码
        /// </summary>
        public string DWDM { set; get; }

        /// <summary>
        /// 应配副职数
        /// </summary>
        public int YPFZS { set; get; }

        /// <summary>
        /// 单位成立批准文号
        /// </summary>
        public string DWCLPZWH { set; get; }

        /// <summary>
        /// 单位名称补充
        /// </summary>
        public string DWMCBC { set; get; }

        /// <summary>
        /// 单位简称三
        /// </summary>
        public string DWJC3 { set; get; }

        /// <summary>
        /// 归口管理单位名称
        /// </summary>
        public string GKGLDWMC { set; get; }

        /// <summary>
        /// 单位所属系统
        /// </summary>
        public string DWSSXT { set; get; }

        /// <summary>
        /// 归口管理单位名称补充
        /// </summary>
        public string GKGLDWMCBC { set; get; }

        /// <summary>
        /// 应配职数补充
        /// </summary>
        public string YPZSBC { set; get; }

        /// <summary>
        /// 单位名称类别
        /// </summary>
        public string DWMCLB { set; get; }

        /// <summary>
        /// 有中共党员标识
        /// </summary>
        public string YZGDYBSS { set; get; }

        /// <summary>
        /// 应配正职数
        /// </summary>
        public int YPZZS { set; get; }

        /// <summary>
        /// 领导班子协管单位名称
        /// </summary>
        public string LDBZXGDWMC { set; get; }

        /// <summary>
        /// 单位变更原因
        /// </summary>
        public string DWBGYY { set; get; }

        /// <summary>
        /// 干部管理单位标示
        /// </summary>
        public int GBGLDWBS { set; get; }

        /// <summary>
        /// 单位所在政区
        /// </summary>
        public string DWSZZQ { set; get; }

        /// <summary>
        /// 单位性质类别
        /// </summary>
        public string DWXZLB { set; get; }

        /// <summary>
        /// 单位编码
        /// </summary>
        public string DWBM { set; get; }

        /// <summary>
        /// 现有副职数
        /// </summary>
        public int XYFZS { set; get; }

        /// <summary>
        /// 单位撤销批准文号
        /// </summary>
        public string DWCXPZWH { set; get; }

        /// <summary>
        /// 单位所属行业
        /// </summary>
        public string DWSHY { set; get; }

        /// <summary>
        /// 机构统计标识
        /// </summary>
        public string JGTJBS { set; get; }

        /// <summary>
        /// 领导班子主管单位名称补充
        /// </summary>
        public string LDBZZGDWMCBC { set; get; }

        /// <summary>
        /// 隶属单位名称补充
        /// </summary>
        public string LSDWMCBC { set; get; }

        /// <summary>
        /// 党管单位标示
        /// </summary>
        public int DGDWBS { set; get; }

        /// <summary>
        /// 单位级别
        /// </summary>
        public string DWJB { set; get; }

        /// <summary>
        /// 单位简称
        /// </summary>
        public string DWJC { set; get; }

        /// <summary>
        /// 单位工作职能
        /// </summary>
        public string DWGZZN { set; get; }

        /// <summary>
        /// 单位管理层次标识
        /// </summary>
        public string DWGLCCBS { set; get; }

        /// <summary>
        /// 单位所属部门统计标识
        /// </summary>
        public string DWSSBMTJBS { set; get; }

        /// <summary>
        /// 单位撤销批准机关名称补充
        /// </summary>
        public string DWCXPZJGMCBC { set; get; }

        /// <summary>
        /// 有中共组织标识
        /// </summary>
        public string YZGZZBS { set; get; }

        /// <summary>
        /// 归口管理处室
        /// </summary>
        public string GKGLCS { set; get; }

        /// <summary>
        /// 副书记职数
        /// </summary>
        public string FSJZS { set; get; }

        /// <summary>
        /// 单位备注
        /// </summary>
        public string DWBZ { set; get; }

        /// <summary>
        /// 领导班子主管单位名称
        /// </summary>
        public string LDBZZGDWMC { set; get; }

        /// <summary>
        /// 照片
        /// </summary>
        public string ZP { set; get; }

        /// <summary>
        /// 隶属单位名称
        /// </summary>
        public string LSDWMC { set; get; }

        /// <summary>
        /// 现有正职数
        /// </summary>
        public int XYZZS { set; get; }

        /// <summary>
        /// 单位影像
        /// </summary>
        public string DWYX { set; get; }

        /// <summary>
        /// 单位成立批准日期
        /// </summary>
        public string DWCLPZRQ { set; get; }

        /// <summary>
        /// 单位隶属关系
        /// </summary>
        public string DWLSGX { set; get; }

        /// <summary>
        /// 单位撤销批准机关名称
        /// </summary>
        public string DWCXPZJGMC { set; get; }

        /// <summary>
        /// 单位成立批准机关名称补充
        /// </summary>
        public string DWCLPZJGMCBC { set; get; }

        /// <summary>
        /// 单位管理职能类别
        /// </summary>
        public string DWGLZNLB { set; get; }

        /// <summary>
        /// 单位成立批准机关名称
        /// </summary>
        public string DWCLPZJGMC { set; get; }

        /// <summary>
        /// 单位所属系统（名册）
        /// </summary>
        public string DWSSXTMC { set; get; }

        /// <summary>
        /// 单位负责人
        /// </summary>
        public string DWFZR { set; get; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string DWMC { set; get; }

        /// <summary>
        /// 法人单位标识
        /// </summary>
        public int FRDWBS { set; get; }

        /// <summary>
        /// 与隶属单位关系标识
        /// </summary>
        public string YLSDWGXBS { set; get; }

        /// <summary>
        /// 领导班子协管单位名称补充
        /// </summary>
        public string LDBZXGDWMCBC { set; get; }

        /// <summary>
        /// 单位撤销批准日期
        /// </summary>
        public string DWCXPZRQ { set; get; }

        /// <summary>
        /// 单位缩名
        /// </summary>
        public string DWSM { set; get; }





    }
}
