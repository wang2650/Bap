using System;
using System.Linq;
using System.Text;
using SqlSugar;


namespace WXQ.Enties.DbModels
{
    [SugarTable("tb_userbaseinfo")]
    public partial class UserBaseInfo
    {
        public UserBaseInfo()
        {


        }/// <summary>
         /// 人员标识符
         /// </summary>
        public string UserSn { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 名字对应拼音
        /// </summary>
        public string UserNamePY { set; get; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { set; get; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { set; get; }


        /// <summary>
        /// 籍贯
        /// </summary>
        public string Native { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        public string BirthPlace { get; set; }


        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { set; get; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrganizationName { set; get; }

        /// <summary>
        /// 单位名称补充
        /// </summary>
        public string OrganizationExtendInfo { set; get; }

        /// <summary>
        /// 职级
        /// </summary>
        public string JobLevel { set; get; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// 家庭出身
        /// </summary>
        public string Family { set; get; }

        /// <summary>
        /// 成分
        /// </summary>
        public string Composition { set; get; }

        /// <summary>
        /// 职称
        /// </summary>
        public string PositionalTitles { set; get; }

        /// <summary>
        /// 任现职时间
        /// </summary>
        public string TakeOffice { set; get; }

        /// <summary>
        /// 健康
        /// </summary>
        public string Health { set; get; }

        /// <summary>
        /// 学历
        /// </summary>
        public string EducationalBackground { set; get; }

        /// <summary>
        /// 毕业学校
        /// </summary>
        public string School { set; get; }

        /// <summary>
        /// 学历级别
        /// </summary>
        public string EducationalLevel { set; get; }

        /// <summary>
        /// 学位
        /// </summary>
        public string Degree { set; get; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Marital { set; get; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Major { set; get; }

        /// <summary>
        /// 乡镇工作时间
        /// </summary>
        public int Worktime { set; get; }

        /// <summary>
        /// 参加工作时间
        /// </summary>
        public string JoinJobTime { set; get; }

        /// <summary>
        /// 工龄计算矫正值
        /// </summary>
        public int WorkTimeCorrect { set; get; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string PoliticsStatus { set; get; }

        /// <summary>
        /// 参加组织日期
        /// </summary>
        public string JoinOrgDate { set; get; }

        /// <summary>
        /// 政治面貌注释标识
        /// </summary>
        public string PoliticsRemarkTag { set; get; }

        /// <summary>
        /// 个人身份
        /// </summary>
        public string Identity { set; get; }

        /// <summary>
        /// 现身份起始日期
        /// </summary>
        public string IdentityBeginDate { set; get; }

        /// <summary>
        /// 人事关系所在单位名称
        /// </summary>
        public string CompanyNameOfOrgAffiliation { set; get; }

        /// <summary>
        /// 人事关系所在单位名称类别
        /// </summary>
        public string CompanyNameClassOfOrgAffiliation { set; get; }

        /// <summary>
        /// 人事关系所在单位所在政区
        /// </summary>
        public string CompanyAreaOfOrgAffiliation { set; get; }

        /// <summary>
        /// 人事关系所在单位隶属关系
        /// </summary>
        public string BelongTOCompanyOfOrgAffiliation { set; get; }

        /// <summary>
        /// 管理类别
        /// </summary>
        public string ManageClass { set; get; }

        /// <summary>
        /// 人事关系所在单位级别
        /// </summary>
        public string CompanyLevelOfOrgAffiliation { set; get; }

        /// <summary>
        /// 人事关系所在单位性质类别
        /// </summary>
        public string CompanyNatureOfOrgAffiliation { set; get; }

        /// <summary>
        /// 人事关系所在单位所属行业
        /// </summary>
        public string CompanyIndustryOfOrgAffiliation { set; get; }

        /// <summary>
        /// 户口性质
        /// </summary>
        public string RegisteredNature { set; get; }

        /// <summary>
        /// 户口所在地代码
        /// </summary>
        public string RegisteredAreaCode { set; get; }

        /// <summary>
        /// 户口所在地
        /// </summary>
        public string RegisteredArea { set; get; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string UserIdCode { set; get; }

        /// <summary>
        /// 特长
        /// </summary>
        public string Specialty { set; get; }

        /// <summary>
        /// 爱好
        /// </summary>
        public string Hobby { set; get; }

        /// <summary>
        /// 现任职务
        /// </summary>
        public string Duty { set; get; }

        /// <summary>
        /// 声像信息标识
        /// </summary>
        public string MediaInfoFlag { set; get; }

        /// <summary>
        /// 其他任职情况
        /// </summary>
        public string OtherDuty { set; get; }

        /// <summary>
        /// 显示方式
        /// </summary>
        public string DisplayType { set; get; }

        /// <summary>
        /// 基层工作时间
        /// </summary>
        public int BaseWorkDate { set; get; }

        /// <summary>
        /// 进入干部队伍方式
        /// </summary>
        public string JoinArmyType { set; get; }

        /// <summary>
        /// 工作岗位
        /// </summary>
        public string PostDuty { set; get; }

        /// <summary>
        /// 工资关系所在单位
        /// </summary>
        public string CompanyOfSalary { set; get; }

        /// <summary>
        /// 照片
        /// </summary>
        public string Photo { set; get; }

        /// <summary>
        /// 录像mpeg
        /// </summary>
        public string AviMpeg { set; get; }

        /// <summary>
        /// 人员管理状态
        /// </summary>
        public string UserManageState { set; get; }

        /// <summary>
        /// 干部类别
        /// </summary>
        public string LeaderType { set; get; }

        /// <summary>
        /// 党员管理状态
        /// </summary>
        public string PartyManageState { set; get; }

        /// <summary>
        /// 籍贯补充
        /// </summary>
        public string NativePlaceReplenish { set; get; }

        /// <summary>
        /// 人员所在党组织代码
        /// </summary>
        public string PartyCode { set; get; }

        /// <summary>
        /// 出生地补充
        /// </summary>
        public string BirthPlaceReplenish { set; get; }

        /// <summary>
        /// 主管单位
        /// </summary>
        public string GovernorCompany { set; get; }

        /// <summary>
        /// 统计关系所在单位
        /// </summary>
        public string StatisticsRefCompany { set; get; }

        /// <summary>
        /// 职工号
        /// </summary>
        public string WorkerSn { set; get; }

        /// <summary>
        /// 公务员登记时间
        /// </summary>
        public string PublicServantRegDate { set; get; }

        /// <summary>
        /// 人事关系所在单位名称补充
        /// </summary>
        public string CompanyNameReplenishOfOrgAffiliation { set; get; }

        /// <summary>
        /// 干部党员标识
        /// </summary>
        public int PartyFlag { set; get; }

        /// <summary>
        /// 职称级别
        /// </summary>
        public string TitleLevel { set; get; }

        /// <summary>
        /// 同步
        /// </summary>
        public string Syn { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { set; get; }

        /// <summary>
        /// 全局唯一标识
        /// </summary>
        public string UniquenessId { set; get; }

        /// <summary>
        /// 权限检测
        /// </summary>
        public string RightCheck { set; get; }

        /// <summary>
        /// 归口调整
        /// </summary>
        public string CentralizedAdjust { set; get; }

        /// <summary>
        /// 省/市管时间
        /// </summary>
        public string ProvinceCityDate { set; get; }

        /// <summary>
        /// 参公
        /// </summary>
        public int CanGong { set; get; }

    }
}
