using AspectCore.Injector;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
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
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public void ConfigureContainer(IServiceContainer builder)
        {
            // 这里就是熟悉的味道了。。。
            builder.Configure(config =>
            {
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseCors("mycors");
            app.UseOptions();

            #region Swagger

            /*使用NLog*/
            loggerFactory.AddNLog();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", $"{ApiName}");
                c.RoutePrefix = "swagger"; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉
            });

            #endregion Swagger
          
            NLog.LogManager.LoadConfiguration("nlog.config");
            NLog.LogManager.Configuration.Variables["ConnectionStrings"] = AppConfigurtaionServices.Configuration.GetConnectionString("wxqconn");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  //避免日志中的中文输出乱码

            // 跳转https
            //app.UseHttpsRedirection();
            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            // app.UseCookiePolicy();
            // 返回错误码

            app.UseStatusCodePages();//把错误码返回前台，比如是404

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

   
       
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IAsyncAuthorizationFilter, WebApi.Common.MiddleWare.AuthorizeAttribute>();
            //添加cors 服务 配置跨域处理
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => builder
           
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            });
            services.AddMvcCore().AddFluentValidation().AddApiExplorer();
            services.AddMvc(
           o =>
           {
               // 全局异常过滤
               o.Filters.Add(typeof(GlobalExceptionsFilter));
           }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            #region Swagger UI Service

            string basePath =Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档",
                    Description = $"{ApiName} HTTP API " + "V1",

                    Contact = new OpenApiContact { Name = "WXQ", Email = "Wang2650@163.com", Url = new Uri("http://www.baidu.com") }
                });
                // 按相对路径排序，作者：Alby
                c.OrderActionsBy(o => o.RelativePath);

                //就是这里
                string xmlPath = Path.Combine(basePath, "WebApi.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                #region Token绑定到ConfigureServices

                //添加header验证信息

                // c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<WebApi.Common.MiddleWare.AuthorizeAttribute>>();
                // c.OperationFilter<AddHeaderOperationFilter>("Authorization", "Correlation Id for the request", false);
                // 发行人
                string IssuerName = (Configuration.GetSection("Audience"))["Issuer"];
                Dictionary<string, IEnumerable<string>> security = new Dictionary<string, IEnumerable<string>> { { IssuerName, new string[] { } }, };

                var oasScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference()
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    },

                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入 {token}",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//
                    Type = SecuritySchemeType.ApiKey
                };
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    { oasScheme, new List<string>()}
                });

                c.AddSecurityDefinition("Bearer", oasScheme);

                #endregion Token绑定到ConfigureServices
            });

            #endregion Swagger UI Service

            //读取配置文件
            IConfigurationSection audienceConfig = Configuration.GetSection("Audience");
            string symmetricKeyAsBase64 = audienceConfig["Secret"];
            byte[] keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            SymmetricSecurityKey signingKey = new SymmetricSecurityKey(keyByteArray);
            //#region 【认证】
            ////2.1【认证】
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("common", policy => policy.Requirements.Add(new CommonAuthorizeRequirement("common")));
            //}).AddAuthentication(x =>
            //   {
            //       x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //       x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //   })
            //.AddJwtBearer(o =>
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = signingKey,
            //        ValidateIssuer = true,
            //        ValidIssuer = audienceConfig["Issuer"],//发行人
            //         ValidateAudience = true,
            //        ValidAudience = audienceConfig["Audience"],//订阅人
            //         ValidateLifetime = true,
            //        ClockSkew = TimeSpan.Zero,
            //        RequireExpirationTime = true,
            //    };
            //});

            //#endregion 【认证】
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });

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

            WebApi.ClassMapper.TypeAdapter typeAdapter = new WebApi.ClassMapper.TypeAdapter();
            typeAdapter.Init();
        }
    }
}