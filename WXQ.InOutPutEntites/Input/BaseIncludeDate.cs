using System;
using System.Collections.Generic;
using System.Text;

namespace WXQ.InOutPutEntites.Input
{
    /// <summary>
    /// 带开始结束时间的入参
    /// </summary>
  public   class BaseIncludeDate
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDt { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDt { get; set; }


    }
}
