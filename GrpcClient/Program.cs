using Grpc.Core;
using MagicOnion.Client;
using System;

namespace GrpcClient
{
    class Program
    {
        private static Channel _channel;
        private static IMyFirstService _client;

        static void Main(string[] args)
        {
            _channel = new Channel("localhost", 12345, ChannelCredentials.Insecure);

            // get MagicOnion dynamic client proxy
            _client = MagicOnionClient.Create<IMyFirstService>(_channel);
            testy();
        }

        public async static void testy()
        {
        

            // call method.
            var result = _client.SumAsync(100, 200).ResponseAsync.Result;
            Console.WriteLine("客户端结果:" + result);

            result = _client.SumAsync(190, 200).ResponseAsync.Result;
            Console.WriteLine("客户端结果:" + result);


            result = _client.SumAsync(10, 290).ResponseAsync.Result;
            Console.WriteLine("客户端结果:" + result);


            result = _client.SumAsync(65, 233).ResponseAsync.Result;
            Console.WriteLine("客户端结果:" + result);

        }



    }
}
