using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.Enties.CommonObj
{
  public  class MenuTree
    {


 


        /// <summary>
        /// 索引
        /// </summary>
        public string index { get; set; } = "";


        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; } = "";

        /// <summary>
        /// 子节点
        /// </summary>
        public List<MenuTree> subs { get; set; } = new List<MenuTree>();
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; } = "";


    }
}
