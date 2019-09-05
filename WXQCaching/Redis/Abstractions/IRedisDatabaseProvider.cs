using StackExchange.Redis;
using System.Collections.Generic;

namespace WXQ.Caching.StackExchangeRedis.Abstractions
{
    public interface IRedisDatabaseProvider
    {
        string DbProviderName { get; }
        bool IsConnected { get; }
        bool TryConnect();
        IDatabase GetDatabase();
        IEnumerable<IServer> GetServerList();
    }
}
