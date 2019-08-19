using SqlSugar;
using System;
using WXQ.Enties.DbModels;

namespace WXQ.Enties
{
    ///<summary>
    ///部门
    ///</summary>
    [SugarTable( "tb_department","部门")]
    public partial class Department: BaseModel
    {
        public Department()
        {
        }
     
        /// <summary>
        /// Desc:部门名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = false,ColumnDescription = "部门名")]
        public string DepartmentName { get; set; } = "";

        /// <summary>
        ///   描述
        /// </summary>
        [SugarColumn(Length = 200, IsNullable = false, ColumnDescription = "描述")] public string Description { get; set; } = "";


        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
        public int DepartmentId { get; set; }

  
        /// <summary>
        /// 父id
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "父id")] public int ParentId { get; set; } = -1;


    }
}