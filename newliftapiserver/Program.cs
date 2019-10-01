using System;
using NewLife.Data;
using NewLife.Log;
using NewLife.Net;
using NewLife.Net.Handlers;
using NewLife.Remoting;
using NewLife.Threading;

namespace newliftapiserver
{
    class Program
    {
        static TimerX _timer;
        static ApiServer _server;
        static void Main(string[] args)
        {
            // 实例化RPC服务端，指定端口，同时在Tcp/Udp/IPv4/IPv6上监听
            var svr = new ApiServer(8084);
            // 注册服务控制器
            svr.Register<MyController>();
            svr.Register<UserController>();

            // 指定编码器
            svr.Encoder = new JsonEncoder();
            svr.EncoderLog = XTrace.Log;
           // svr.Log = XTrace.Log;
            var ns = svr.EnsureCreate() as NetServer;

            //ns.Log = XTrace.Log;
            //ns.LogSend = true;
            //ns.LogReceive = true;

            //svr.Log = XTrace.Log;
       
            svr.Start();
     _server = svr;
            Console.WriteLine("OK99999999!");
            // 定时显示性能数据
           // _timer = new TimerX(ShowStat, ns, 100, 1000);
            Console.ReadKey();
        }
        static void ShowStat(Object state)
        {
            var msg = "";
            if (state is NetServer ns)
                msg = ns.GetStat();
            else if (state is ISocketRemote ss)
                msg = ss.GetStat();

            Console.Title = msg;
        }
    }
}
