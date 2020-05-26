using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Common.Helpers
{
    public class DomainHelper
    {

        public static void ClearCache()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
        private static DomainHelper _instance = null;
        private static object _lock = new object();
        public static DomainHelper Create(string path)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DomainHelper();

                        _instance.serverList = new Dictionary<string, string>();
                        StreamReader sr = new StreamReader(path);
                        while (sr.Peek() != -1)
                        {
                            string line = sr.ReadLine();
                            string[] temp = line.Split(new char[] { '\t', ' ' });
                            _instance.serverList.Add(temp[0].ToLower(), temp[1]);
                        }
                    }
                }
            }
            return _instance;
        }

        public Dictionary<string, string> serverList;

        /// <summary>
        /// 获取域名的信息
        /// </summary>
        /// <param name="domain">域名</param>
        /// <param name="filePath">生成的文件路径</param>
        /// <returns></returns>
        public string LookUp(string domain, string filePath = "WhoisServer.txt")
        {
            if (string.IsNullOrEmpty(filePath)) return "";

            Create("WhoisServer.txt");


            string result = "";
            string[] temp = domain.Split('.');
            string suffix = temp[temp.Length - 1].ToLower();// get the last;
            try
            {
                if (null != _instance.serverList)
                {
                    if (!_instance.serverList.Keys.Contains(suffix))
                    {
                        result = string.Format("不支持此后缀：", suffix);
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            string server = _instance.serverList[suffix];
            TcpClient client = new TcpClient();
            NetworkStream ns;
            try
            {
                client.Connect(server, 43);
                ns = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes(domain + "\rn");
                ns.Write(buffer, 0, buffer.Length);
                buffer = new byte[8192];
                int i = ns.Read(buffer, 0, buffer.Length);
                while (i > 0)
                {
                    Encoding encoding = Encoding.UTF8;
                    result += encoding.GetString(buffer, 0, i);
                    i = ns.Read(buffer, 0, buffer.Length);
                }
            }
            catch (SocketException)
            {
                result = "执行错误！";
                return result;
            }
            ns.Close();
            client.Close();

            return result;
        }

    }
}
