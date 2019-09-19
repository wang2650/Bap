using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using System;
namespace GrpcServer
{
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        // You can use async syntax directly.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Logger.Debug($"Received:{x}, {y}");

            return x + y;
        }
    }
}
