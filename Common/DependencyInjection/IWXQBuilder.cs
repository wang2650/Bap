using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommonLib.DependencyInjection
{
    public interface IWXQBuilder
    {
        IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
    }
}
