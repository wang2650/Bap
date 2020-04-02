using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Common.SystemInfo
{
    public static class EnvironmentInfo
    {
        //static void Main(string[] args)
        //{
        //    var a = EnvironmentInfo.GetApplicationRunInfo();
        //    var b = EnvironmentInfo.GetSystemPlatformInfo();
        //    var c = EnvironmentInfo.GetSystemRunEvnInfo();
        //    var d = EnvironmentInfo.GetEnvironmentVariables();
        //    ConsoleInfo(a.Item1, a.Item2);
        //    ConsoleInfo(b.Item1, b.Item2);
        //    ConsoleInfo(c.Item1, c.Item2);
        //    ConsoleInfo(d.Item1, d.Item2);
        //    Console.ReadKey();
        //}
        //public static void ConsoleInfo(string title, List<KeyValuePair<string, object>> list)
        //{
        //    Console.WriteLine("n***********" + title + "***********");
        //    foreach (var item in list)
        //    {
        //        Console.WriteLine(item.Key + ":" + item.Value);
        //    }
        //}

        #region 获取信息

        /// <summary>
        /// 获取程序运行资源信息
        /// </summary>
        /// <returns></returns>
        public static (string, List<KeyValuePair<string, object>>) GetApplicationRunInfo()
        {
            ApplicationRunInfo info = new ApplicationRunInfo();
            return GetValues(info);
        }

        /// <summary>
        /// 获取系统运行平台信息
        /// </summary>
        /// <returns></returns>
        public static (string, List<KeyValuePair<string, object>>) GetSystemPlatformInfo()
        {
            SystemPlatformInfo info = new SystemPlatformInfo();
            return GetValues(info);
        }

        /// <summary>
        /// 获取系统运行环境信息
        /// </summary>
        /// <returns></returns>
        public static (string, List<KeyValuePair<string, object>>) GetSystemRunEvnInfo()
        {
            SystemRunEvnInfo info = new SystemRunEvnInfo();
            return GetValues(info);
        }

        /// <summary>
        /// 获取系统全部环境变量
        /// </summary>
        /// <returns></returns>
        public static (string, List<KeyValuePair<string, object>>) GetEnvironmentVariables()
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry de in environmentVariables)
            {
                list.Add(new KeyValuePair<string, object>(de.Key.ToString(), de.Value));
            }
            return ("系统环境变量", list);
        }

        #endregion 获取信息

        #region 工具

        /// <summary>
        /// 获取某个类型的值以及名称
        /// </summary>
        /// <typeparam name="TInfo"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        private static (string, List<KeyValuePair<string, object>>) GetValues<TInfo>(TInfo info)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
            Type type = info.GetType();
            PropertyInfo[] pros = type.GetProperties();
            foreach (var item in pros)
            {
                var name = GetDisplayNameValue(item.GetCustomAttributesData());
                var value = GetPropertyInfoValue(item, info);
                list.Add(new KeyValuePair<string, object>(name, value));
            }
            return
                (GetDisplayNameValue(info.GetType().GetCustomAttributesData()),
                list);
        }

        /// <summary>
        /// 获取 [Display] 特性的属性 Name 的值
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private static string GetDisplayNameValue(IList<CustomAttributeData> attrs)
        {
            var argument = attrs.FirstOrDefault(x => x.AttributeType.Name == nameof(DisplayAttribute)).NamedArguments;
            return argument.FirstOrDefault(x => x.MemberName == nameof(DisplayAttribute.Name)).TypedValue.Value.ToString();
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="info"></param>
        /// <param name="obj">实例</param>
        /// <returns></returns>
        private static object GetPropertyInfoValue(PropertyInfo info, object obj)
        {
            return info.GetValue(obj);
        }

        #endregion 工具
    }
}