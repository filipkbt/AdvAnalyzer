using AdvAnalyzer.WebApi.Helpers;
using AdvAnalyzer.WebApi.Models;
using AdvAnalyzer.WebApi.Repositories;
using AdvAnalyzer.WebApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvAnalyzer.WebApi
{
    public class Startup
    {
        private readonly ILogger _serilogLogger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _serilogLogger = new LoggerConfiguration()
                .WriteTo.File(
                "logs/log.log",
                rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AdvAnalyzerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));


            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                      .AddJwtBearer(options =>
                      {
                          options.TokenValidationParameters = new TokenValidationParameters
                          {
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                                  .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                              ValidateIssuer = false,
                              ValidateAudience = false
                          };
                      });
            var emailConfig = Configuration
                    .GetSection("EmailConfiguration")
                    .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            AddRepositories(services);
            AddServices(services);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<AdvAnalyzerContext>().Database.Migrate();
            }
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ISearchQueryRepository, SearchQueryRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IChartRepository, ChartRepository>();
        }

        private void AddServices(IServiceCollection services)
        {

            services.AddScoped<IOlxScraper, OlxScraper>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddHostedService<OlxScrapperScheduler3min>();
            services.AddHostedService<OlxScrapperScheduler5min>();
            services.AddHostedService<OlxScrapperScheduler15min>();
            services.AddHostedService<OlxScrapperScheduler30min>();
            services.AddHostedService<OlxScrapperScheduler60min>();
        }
    }
}
