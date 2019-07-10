using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using CommonLib.Tools;

namespace CommonLib.Extensions.Security
{
    public static class IdentityExtensions
    {
        /// <summary>
        /// 获取指定键名的值
        /// </summary>
        /// <param name="identity">标识</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetValue(this IIdentity identity, string key)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(key);
            return (claim != null) ? claim.Value : string.Empty;
        }

        /// <summary>
        /// 获取指定键名的值
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="identity">标识</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static T GetValue<T>(this IIdentity identity, string key)
        {
            return ConvHelper.To<T>(identity.GetValue(key));
        }
    }
}
