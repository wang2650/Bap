﻿using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CommonLib.Extensions
{
    public static class DecimalExtension
    {
        #region Rounding(将数值四舍五入，保留指定小数位数)

        /// <summary>
        /// 将数值四舍五入，保留两位小数
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static decimal Rounding(this decimal value)
        {
            return Math.Round(value, 2);
        }

        /// <summary>
        /// 将数值四舍五入，保留指定小数位数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public static decimal Rounding(this decimal value, int decimals)
        {
            return Math.Round(value, decimals);
        }

        #endregion

        #region Abs(返回数字的绝对值)

        /// <summary>
        /// 返回数字的绝对值
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static decimal Abs(this decimal value)
        {
            return Math.Abs(value);
        }



        #endregion
    }
}
