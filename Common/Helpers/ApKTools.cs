using System;
using System.Diagnostics;
using System.IO;

namespace Common.Helpers
{
    public class ApKTools
    { /// <summary>
      ///  apktool反编译apk文件  Path.DirectorySeparatorChar 系统的路径分隔符（Linux为左斜杠 windows为右斜杠）
      /// </summary>
      /// <param name="url">待反编译的apk文件</param>
      /// <param name="apkToolsPath">apktool.jar路径</param>
      /// <returns></returns>
        public static bool DecompileApkFile(string url,string apkToolsPath)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            string dirName = Path.GetDirectoryName(url);
            string fileName = Path.GetFileNameWithoutExtension(url);
            proc.Start();
            proc.StandardInput.WriteLine("java -jar "+ apkToolsPath + " d -f " + url + " -o " + dirName + "/" + fileName);
            proc.StandardInput.WriteLine("exit");
            string outStr = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            proc.Close();//关闭进程
            proc.Dispose();//释放资源
            try
            {
                File.Delete(Path.GetDirectoryName(url) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(url) + "/apktool.yml");
            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}