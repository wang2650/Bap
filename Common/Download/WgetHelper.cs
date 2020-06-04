using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CommonLib.Helpers;
namespace Common.Download
{
    public class WgetHelper
    {  /// <summary>
       /// 通过wget方式下载网站
       /// </summary>
       /// <param name="websiteUrl">网址  如 https://www.mgdc81.com/</param>
       /// <param name="fileSavePath">下载文件保存路径 如e:\\website</param>
       /// <param name="downloadLogFilePath">下载网站的日志文件保存路径 如e:\\websitelog.log</param>
       /// /// <param name="wgetExePath">wget程序路径 默认@"C:\Windows\System32\wget.exe" </param>
       /// /// <param name="isWaaitForExit">是否等待程序结束 默认否</param>
        public static bool DownLoadWebsite(string websiteUrl, string fileSavePath, string downloadLogFilePath, string wgetExePath = "")
        {
            try
            {


                Process proc = new Process();
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                proc.StandardInput.WriteLine(wgetExePath + "  - r - p - k - nv - e robots = off   " + websiteUrl + " - P   " + fileSavePath + "--no - check - certificate - o  " + downloadLogFilePath + "--user - agent =\'Mozilla/5.0 (Linux; U; Android 2.3.6; zh-cn; U8860 Build/HuaweiU8860) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1\'");
                proc.StandardInput.WriteLine("exit");
                string outStr = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                proc.Close();//关闭进程
                proc.Dispose();//释放资源

                return true;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// wget是否下载成功  通过判断日志文件的最后一行内容是否为Downloaded开头
        /// </summary>
        /// <param name="downloadLogFilePath">日志文件路径</param>
        /// <returns></returns>
        public static bool DownloadIsSuccess(string downloadLogFilePath)
        {

            String lastLineInfo = CommonLib.IO.FileHelper.GetLastLineDataForTxt(downloadLogFilePath);
            if (string.IsNullOrEmpty(lastLineInfo)) return false;
            string lastLineFirstString = "Downloaded".ToLower();//wget日志的最后一行的字符串内容 以Downloaded开头
            if (lastLineInfo.Length < lastLineFirstString.Length) return false;
            return lastLineInfo.Substring(0, lastLineFirstString.Length).ToLower() == lastLineFirstString;



        }

    }
}
