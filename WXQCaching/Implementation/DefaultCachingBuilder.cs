﻿using WXQ.Caching.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WXQ.Caching.Implementation
{
    public class DefaultCachingBuilder : ICachingBuilder
    {
        public IServiceCollection Services { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public DefaultCachingBuilder(IServiceCollection services, IConfiguration configurationRoot)
        {
            Configuration = configurationRoot;
            Services = services;
        }
    }
}
