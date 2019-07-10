using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Extensions
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// 获取真实的异常信息
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <returns>真实异常</returns>
        public static Exception Unwrap(this Exception ex)
        {
            var counter = 64;
            while (counter-- > 0)
            {
                if (ex is AggregateException && ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                else
                {
                    break;
                }
            }
            return ex;
        }
    }
}
