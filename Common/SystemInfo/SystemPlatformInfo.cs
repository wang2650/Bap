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
    [Display(Name = "系统运行平台")]
    public class SystemPlatformInfo
    {
        [Display(Name = "运行框架")]
        public string FrameworkDescription { get { return RuntimeInformation.FrameworkDescription; } }
        [Display(Name = "操作系统")]
        public string OSDescription { get { return RuntimeInformation.OSDescription; } }
        [Display(Name = "操作系统版本")]
        public string OSVersion { get { return Environment.OSVersion.ToString(); } }
        [Display(Name = "平台架构")]
        public string OSArchitecture { get { return RuntimeInformation.OSArchitecture.ToString(); } }
    }
}
