using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_administrativejobinfo")]
    public partial class AdministrativeJobInfo
    {

        public AdministrativeJobInfo()
        {

        }

        /// <summary>
        /// 人员标识符
        /// </summary>
        public string UserSn { set; get; }

        /// <summary>
        /// 任职机构名称
        /// </summary>
        public string RZJGMC { set; get; }

        /// <summary>
        /// 任职机构名称类别
        /// </summary>
        public string RZJGMCLB { set; get; }

        /// <summary>
        /// 任职机构所在政区
        /// </summary>
        public string RZJGSZZQ { set; get; }

        /// <summary>
        /// 任职机构隶属关系
        /// </summary>
        public string RZJGLSGX { set; get; }

        /// <summary>
        /// 任职机构级别
        /// </summary>
        public string RZJGJB { set; get; }

        /// <summary>
        /// 任职机构性质类别
        /// </summary>
        public string RZJGXZLB { set; get; }

        /// <summary>
        /// 任职机构所属行业
        /// </summary>
        public string RZJGSHY { set; get; }

        /// <summary>
        /// 任职机构统计标识
        /// </summary>
        public string RZJGTJBS { set; get; }

        /// <summary>
        /// 职务代码
        /// </summary>
        public string ZWDM { set; get; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string ZWMC { set; get; }

        /// <summary>
        /// 职务说明
        /// </summary>
        public string ZWSM { set; get; }

        /// <summary>
        /// 班子成员类别
        /// </summary>
        public string BZCYLB { set; get; }

        /// <summary>
        /// 职务补充2
        /// </summary>
        public string ZWBC2 { set; get; }

        /// <summary>
        /// 职级
        /// </summary>
        public string ZJ { set; get; }

        /// <summary>
        /// 多职务主次序号
        /// </summary>
        public int DZWZCXH { set; get; }

        /// <summary>
        /// 集体内排列顺序
        /// </summary>
        public int JTNPLSX { set; get; }

        /// <summary>
        /// 所在工作系统管理职能类别
        /// </summary>
        public string SZGZXTGLZNLB { set; get; }

        /// <summary>
        /// 主管（从事）工作
        /// </summary>
        public string ZGGZ { set; get; }

        /// <summary>
        /// 职业类别
        /// </summary>
        public string ZYLB { set; get; }

        /// <summary>
        /// 从事专业
        /// </summary>
        public string CSZY { set; get; }

        /// <summary>
        /// 决定或提名任职的机关名称
        /// </summary>
        public string JDHTMRZDJGMC { set; get; }

        /// <summary>
        /// 决定或提名任职的日期
        /// </summary>
        public string JDHTMRZDRQ { set; get; }

        /// <summary>
        /// 决定或提名任职的文号
        /// </summary>
        public string JDHTMRZDWH { set; get; }

        /// <summary>
        /// 批准任职机关名称补充
        /// </summary>
        public string PZRZJGMCBC { set; get; }

        /// <summary>
        /// 批准任职机关名称
        /// </summary>
        public string PZRZJGMC { set; get; }

        /// <summary>
        /// 批准任职的日期
        /// </summary>
        public string PZRZDRQ { set; get; }

        /// <summary>
        /// 批准任职的文号
        /// </summary>
        public string PZRZDWH { set; get; }

        /// <summary>
        /// 任职方式
        /// </summary>
        public string RZFS { set; get; }

        /// <summary>
        /// 任职变动类别
        /// </summary>
        public string RZBDLB { set; get; }

        /// <summary>
        /// 是否破格提拔
        /// </summary>
        public int SFPGTB { set; get; }

        /// <summary>
        /// 连续任该职起始日期
        /// </summary>
        public string LXRGZQRQ { set; get; }

        /// <summary>
        /// 任职状态
        /// </summary>
        public string RZZT { set; get; }

        /// <summary>
        /// 决定或提名免职的机关名称
        /// </summary>
        public string JDHTMMZDJGMC { set; get; }

        /// <summary>
        /// 决定或提名免职的日期
        /// </summary>
        public string JDHTMMZDRQ { set; get; }

        /// <summary>
        /// 决定或提名免职的文号
        /// </summary>
        public string JDHTMMZDWH { set; get; }

        /// <summary>
        /// 批准免职的机关名称
        /// </summary>
        public string PZMZDJGMC { set; get; }

        /// <summary>
        /// 批准免职的日期
        /// </summary>
        public string PZMZDRQ { set; get; }

        /// <summary>
        /// 批准免职的文号
        /// </summary>
        public string PZMZDWH { set; get; }

        /// <summary>
        /// 免职方式
        /// </summary>
        public string MZFS { set; get; }

        /// <summary>
        /// 免职变动类别
        /// </summary>
        public string MZBDLB { set; get; }

        /// <summary>
        /// 是否同步履历
        /// </summary>
        public string SFTBLL { set; get; }

        /// <summary>
        /// 非省管干部
        /// </summary>
        public string FSGGB { set; get; }

        /// <summary>
        /// 班子情况
        /// </summary>
        public string BZQK { set; get; }

        /// <summary>
        /// 统计标识
        /// </summary>
        public int TJBS { set; get; }

        /// <summary>
        /// 是否回避交流
        /// </summary>
        public int SFHBJL { set; get; }

        /// <summary>
        /// 主管工作类别
        /// </summary>
        public string ZGGZLB { set; get; }

        /// <summary>
        /// 试（聘）用期结束日期
        /// </summary>
        public string SYQJSRQ { set; get; }

        /// <summary>
        /// 任职机构名称补充
        /// </summary>
        public string RZJGMCBC { set; get; }

        /// <summary>
        /// 名册职务标识
        /// </summary>
        public int MCZWBS { set; get; }

        /// <summary>
        /// 领导职务标识
        /// </summary>
        public string LDZWB { set; get; }

        /// <summary>
        /// 非班子成员
        /// </summary>
        public int FBZCY { set; get; }

        /// <summary>
        /// 交流类别
        /// </summary>
        public string JLLB { set; get; }

        /// <summary>
        /// 是否存在任前公示
        /// </summary>
        public int SFCZRQGS { set; get; }

        /// <summary>
        /// 本单位职务统计标识
        /// </summary>
        public int BDWZWTJBS { set; get; }

        /// <summary>
        /// 决定或提名任职的机关名称补充
        /// </summary>
        public string JDHTMRZDJGMCBC { set; get; }

        /// <summary>
        /// 任职原因类别
        /// </summary>
        public string RZYYLB { set; get; }

        /// <summary>
        /// 决定或提名免职的机关名称补充
        /// </summary>
        public string JDHTMMZDJGMCBC { set; get; }

        /// <summary>
        /// 批准免职的机关名称补充
        /// </summary>
        public string PZMZDJGMCBC { set; get; }

        /// <summary>
        /// 免职原因类别
        /// </summary>
        public string MZYYLB { set; get; }

        /// <summary>
        /// 是否换届
        /// </summary>
        public int SFHZ { set; get; }

        /// <summary>
        /// 换届时间
        /// </summary>
        public string HJSJ { set; get; }

        /// <summary>
        /// 任职年限
        /// </summary>
        public string RZNX { set; get; }

        /// <summary>
        /// 最新任职年限
        /// </summary>
        public string ZXRZNX { set; get; }

        /// <summary>
        /// 多记录序号
        /// </summary>
        public int DJLXH { set; get; }
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string WYBS { set; get; }

        /// <summary>
        /// 单位所属系统
        /// </summary>
        public string DWSXT { set; get; }

    }
}
