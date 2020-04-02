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
    [Display(Name = "运行信息")]
    public class ApplicationRunInfo
    {
        private double _UsedMem;
        private double _UsedCPUTime;
        public ApplicationRunInfo()
        {
            var proc = Process.GetCurrentProcess();
            var mem = proc.WorkingSet64;
            var cpu = proc.TotalProcessorTime;
            _UsedMem = mem / 1024.0;
            _UsedCPUTime = cpu.TotalMilliseconds;
        }
        [Display(Name = "进程已使用物理内存(kb)")]
        public double UsedMem { get { return _UsedMem; } }
        [Display(Name = "进程已占耗CPU时间(ms)")]
        public double UsedCPUTime { get { return _UsedCPUTime; } }
    }
}
