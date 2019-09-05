using WXQ.Caching.Abstractions;
using WXQ.Caching.StackExchangeRedis.Abstractions;
using WXQ.Caching.StackExchangeRedis.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WXQ.Caching.StackExchangeRedis
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 使用StackExchangeRedis缓存
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ICachingBuilder UseStackExchangeRedis(this ICachingBuilder builder, StackExchangeRedisOption option)
        {
            builder.Services.AddSingleton<IRedisDatabaseProvider>(sp =>
            {
                return new RedisDatabaseProvider(option.DbProviderName, option.Configuration);
            });
            builder.Services.AddSingleton<ICachingProvider>(sp =>
            {
                return new DefaultRedisCachingProvider(option.DbProviderName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });
            builder.Services.AddSingleton<IRedisCachingProvider>(sp =>
            {
                return new DefaultRedisFeatureProvider(option.DbProviderName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });
            return builder;
        }
        /// <summary>
        /// 使用StackExchangeRedis缓存
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="redisConfiguration">redis连接字符串</param>
        /// <param name="name">提供者名称</param>
        /// <returns></returns>
        public static ICachingBuilder UseStackExchangeRedis(this ICachingBuilder builder, string redisConfiguration, string providerName)
        {
            builder.Services.AddSingleton<IRedisDatabaseProvider>(sp =>
            {
                return new RedisDatabaseProvider(providerName, redisConfiguration);
            });
            builder.Services.AddSingleton<ICachingProvider>(sp =>
            {
                return new DefaultRedisCachingProvider(providerName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });
            builder.Services.AddSingleton<IRedisCachingProvider>(sp =>
            {
                return new DefaultRedisFeatureProvider(providerName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });
            return builder;
        }
        /// <summary>
        /// 使用StackExchangeRedis缓存,配置注入
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="sectionPath"></param>
        /// <returns></returns>
        public static ICachingBuilder UseStackExchangeRedis(this ICachingBuilder builder, string sectionPath = "Caching:StackExchangeRedis")
        {

            //      "Caching": {
            //          "StackExchangeRedis": {
            //              "Connection": "127.0.0.1:6379,password=12345678",
            //"InstanceName": "实例:"
            //          }
            //      }
            var option =new  StackExchangeRedisOption();
            var section = builder.Configuration.GetSection(sectionPath);
            string _connectionString = section.GetSection("Connection").Value;//连接字符串
            string _instanceName = section.GetSection("InstanceName").Value; //实例名称
            option.DbProviderName = _instanceName;
            option.Configuration = _connectionString;

            builder.Services.AddSingleton<IRedisDatabaseProvider>(sp =>
            {
                return new RedisDatabaseProvider(option.DbProviderName, option.Configuration);
            });
            builder.Services.AddSingleton<ICachingProvider>(sp =>
            {
                return new DefaultRedisCachingProvider(option.DbProviderName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });
            builder.Services.AddSingleton<IRedisCachingProvider>(sp =>
            {
                return new DefaultRedisFeatureProvider(option.DbProviderName, sp.GetServices<IRedisDatabaseProvider>(), sp.GetService<ICachingSerializer>());
            });

            return builder;
        }
    }
}
