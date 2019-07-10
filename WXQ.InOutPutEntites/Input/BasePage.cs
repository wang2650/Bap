using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input
{
    /// <summary>
    /// 带分页条件的入参
    /// </summary>
   public class PageInput
    {
        /// <summary>
        /// 分页索引
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; } = 10;





    }
}
