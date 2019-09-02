using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WXQ.Caching.Abstractions
{
    public interface ICachingBuilder
    {
        IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
    }
}
