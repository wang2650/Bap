﻿using System;
using System.Collections.Generic;
using System.Text;
using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using System;

namespace GrpcClient
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        // Return type must be `UnaryResult<T>` or `Task<UnaryResult<T>>`.
        // If you can use C# 7.0 or newer, recommend to use `UnaryResult<T>`.
        UnaryResult<int> SumAsync(int x, int y);
    }
}
