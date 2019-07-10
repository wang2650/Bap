using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace WXQ.Enties
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("Tb_Menu")]
    public partial class Menu
    {
        public Menu()
        {

            this.MenuName = Convert.ToString("");
            this.Description = Convert.ToString("");
            this.ParentId = Convert.ToInt32("0");
            this.AddDateTime = DateTime.Now;
            this.UpdateDateTime = DateTime.Now;
            this.AddUser = Convert.ToString("");
            this.UpdateUser = Convert.ToString("");
            this.RowVersion = Convert.ToInt32("0");
            this.MenuType = Convert.ToByte("1");
            this.Url = Convert.ToString("");
            this.RsState = Convert.ToByte("1");
            this.Icon = Convert.ToString("el-icon-menu");

        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string MenuName { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Description { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int ParentId { get; set; }

        /// <summary>
        /// Desc:
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime AddDateTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime UpdateDateTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string AddUser { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string UpdateUser { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public int RowVersion { get; set; }

        /// <summary>
        /// Desc:菜单类型
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public byte MenuType { get; set; }

        /// <summary>
        /// Desc:链接地址
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Url { get; set; }

        /// <summary>
        /// Desc:记录状态
        /// Default:1
        /// Nullable:False
        /// </summary>           
        public byte RsState { get; set; }

        /// <summary>
        /// Desc:图标
        /// Default:el-icon-menu
        /// Nullable:False
        /// </summary>           
        public string Icon { get; set; }

    }
}