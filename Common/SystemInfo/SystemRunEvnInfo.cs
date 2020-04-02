using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
namespace Common.SystemInfo
{
    [Display(Name = "运行环境")]
    public class SystemRunEvnInfo
    {
        [Display(Name = "机器名称")]
        public string MachineName { get { return Environment.MachineName; } }
        [Display(Name = "用户网络域名")]
        public string UserDomainName { get { return Environment.UserDomainName; } }
        [Display(Name = "分区磁盘")]
        public string GetLogicalDrives { get { return string.Join(", ", Environment.GetLogicalDrives()); } }
        [Display(Name = "系统目录")]
        public string SystemDirectory { get { return Environment.SystemDirectory; } }
        [Display(Name = "系统已运行时间(毫秒)")]
        public int TickCount { get { return Environment.TickCount; } }

        [Display(Name = "是否在交互模式中运行")]
        public bool UserInteractive { get { return Environment.UserInteractive; } }
        [Display(Name = "当前关联用户名")]
        public string UserName { get { return Environment.UserName; } }
        [Display(Name = "Web程序核心框架版本")]
        public string Version { get { return Environment.Version.ToString(); } }

        //对Linux无效
        [Display(Name = "磁盘分区")]
        public string SystemDrive { get { return Environment.ExpandEnvironmentVariables("%SystemDrive%"); } }
        //对Linux无效
        [Display(Name = "系统目录")]
        public string SystemRoot { get { return Environment.ExpandEnvironmentVariables("%SystemRoot%"); } }
    }
}
