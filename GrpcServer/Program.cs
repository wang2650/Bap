using System;
using System.Threading.Tasks;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using MagicOnion.Hosting;
using Microsoft.Extensions.Hosting;
namespace GrpcServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());


            //// you can use new HostBuilder() instead of CreateDefaultBuilder
            await new HostBuilder()
                .UseMagicOnion()
                .RunConsoleAsync();


            //MagicOnionServiceDefinition service = MagicOnionEngine.BuildServerServiceDefinition(

            //    new[] { typeof(IMyFirstService).Assembly },  // 加载引用程序集
            //    new MagicOnionOptions(true)
            //    {
            //        MagicOnionLogger = new MagicOnionLogToGrpcLogger()
            //    }
            //);

            // setup MagicOnion and option.
            var service = MagicOnionEngine.BuildServerServiceDefinition(isReturnExceptionStackTraceInErrorDetail: true);

            var server = new global::Grpc.Core.Server
            {
                Services = { service },
                Ports = { new ServerPort("localhost", 12345, ServerCredentials.Insecure) }
            };

            // launch gRPC Server.
            server.Start();

            // and wait.
            Console.ReadLine();
        }
    }
}
