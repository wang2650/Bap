using System;
using System;
using System.Diagnostics;
using NewLife.Data;
using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Handlers;
using NewLife.Remoting;
using NewLife.Threading;
namespace newlifeapiclient
{
    class Program
    {
        static TimerX _timer;
        static ApiServer _server;
        static void Main(string[] args)
        {
            XTrace.UseConsole();

            try
            {
               
                    TestClient();
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            Console.WriteLine("OK!");
            Console.ReadKey();
        }

        static async void TestClient()
        {
            var client = new MyClient("tcp://127.0.0.1:8084");

            // 指定编码器
            client.Encoder = new JsonEncoder();
           // client.EncoderLog = XTrace.Log;

            //// 打开原始数据日志
            //var ns = client.Client;
            //ns.Log = XTrace.Log;
            //ns.LogSend = true;
            //ns.LogReceive = true;

            // 定时显示性能数据
            client.StatPeriod = 5;

           // client.Log = XTrace.Log;
            client.Open();

            // 定时显示性能数据
            //_timer = new TimerX(ShowStat, ns, 100, 1000);

            // 标准服务，Json
            var n = await client.AddAsync(1245, 3456);
    

            // 高速服务，二进制
            var buf = "Hello".GetBytes();
            var pk = await client.RC4Async(buf);
          

            // 返回对象
            var user = await client.FindUserAsync(123, true);
       
            // 拦截异常
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Reset();
                sw.Start();
                int res = 0;
                for (int i=0;i<10000;i++)
                {
                     res = await client.AddAsync(123, i);
                
                }
                sw.Stop();
                Console.WriteLine("用时"+ sw.ElapsedMilliseconds.ToString());
              
                
            }

            catch (ApiException ex)
            {
               // XTrace.WriteLine("FindUser出错，错误码={0}，内容={1}", ex.Code, ex.Message);
            }
        }
    }
}
