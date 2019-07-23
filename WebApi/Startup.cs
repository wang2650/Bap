using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApi.Common;

using WebApi.Common.MiddleWare;
using WXQ.Enties.CommonObj;

namespace WebApi
{


    //swagger 默认地址 localhost:5000/index.html
    public class Startup
    {
        private const string ApiName = "WXQManage";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger

            /*使用NLog*/
            loggerFactory.AddNLog();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName}");
                c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉
            });

            #endregion Swagger

            NLog.LogManager.LoadConfiguration("nlog.config");
            NLog.LogManager.Configuration.Variables["ConnectionStrings"] = AppConfigurtaionServices.Configuration.GetConnectionString("wxqconn");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  //避免日志中的中文输出乱码

             app.UseCors("LimitRequests");//将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。
            // 跳转https
            //app.UseHttpsRedirection();
            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();
            app.UseResponseTimeMiddleWare();
            // 返回错误码
            app.UseStatusCodePages();//把错误码返回前台，比如是404
            app.UseMvc();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton

            services.AddMvc(
                o =>
                {
                    // 全局异常过滤
                    o.Filters.Add(typeof(GlobalExceptionsFilter));
                }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddControllersAsServices()
                 .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); }); ;
            services.AddCors(c =>
            {
                c.AddPolicy("AllRequests", policy =>
                {
                    policy
                    .AllowAnyOrigin()//允许任何源
                    .AllowAnyMethod()//允许任何方式
                    .AllowAnyHeader()//允许任何头
                    .AllowCredentials();//允许cookie
                });
                //一般采用这种方法  iis也可以设置
                c.AddPolicy("LimitRequests", policy =>
                {
                    policy
                    .WithOrigins("http://127.0.0.1:8889", "http://localhost:8889")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            }).AddMvcCore().AddFluentValidation().AddApiExplorer();

            #region Swagger UI Service

            string basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Info
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档",
                    Description = $"{ApiName} HTTP API " + "V1",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "WXQ", Email = "Wang2650@163.com", Url = "http://www.baidu.com" }
                });
                // 按相对路径排序，作者：Alby
                c.OrderActionsBy(o => o.RelativePath);

                //就是这里
                string xmlPath = Path.Combine(basePath, "WebApi.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                #region Token绑定到ConfigureServices

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();

                // 发行人
                string IssuerName = (Configuration.GetSection("Audience"))["Issuer"];
                Dictionary<string, IEnumerable<string>> security = new Dictionary<string, IEnumerable<string>> { { IssuerName, new string[] { } }, };
                c.AddSecurityRequirement(security);

                c.AddSecurityDefinition(IssuerName, new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入 {token}",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//
                    Type = "apiKey"
                });

                #endregion Token绑定到ConfigureServices
            });

            #endregion Swagger UI Service

            #region 【认证】

            //读取配置文件
            IConfigurationSection audienceConfig = Configuration.GetSection("Audience");
            string symmetricKeyAsBase64 = audienceConfig["Secret"];
            byte[] keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(keyByteArray);

            //2.1【认证】
            services.AddAuthorization(
                option => option.AddPolicy("common", policy => policy.Requirements.Add(new CommonAuthorize()))
                ).AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = signingKey,
                     ValidateIssuer = true,
                     ValidIssuer = audienceConfig["Issuer"],//发行人
                     ValidateAudience = true,
                     ValidAudience = audienceConfig["Audience"],//订阅人
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero,
                     RequireExpirationTime = true,
                 };
             });
            services.AddSingleton<IAuthorizationHandler, CommonAuthorizeHandler>();

            #endregion 【认证】

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    List<string> errors = context.ModelState
                        .Values
                        .SelectMany(x => x.Errors
                                    .Select(p => p.ErrorMessage))
                        .ToList();

                    WXQ.InOutPutEntites.Output.ResponseResult result = new WXQ.InOutPutEntites.Output.ResponseResult
                    (
                      ResponseResultMessageDefine.ParaError,
                      ResponseResultMessageDefine.ParaErrorMessage

                   );

                    return new BadRequestObjectResult(result);
                };
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            WebApi.ClassMapper.TypeAdapter typeAdapter = new WebApi.ClassMapper.TypeAdapter();
            typeAdapter.Init();

            IServiceContainer serviceContainer = services.ToServiceContainer();//容器
            return serviceContainer.Build();
        }
    }
}