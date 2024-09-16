using Asp.Versioning;
using CodebookService;
using Core.Base.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Model;
using OrganizationService;
using Repository;
using System;
using System.Linq;
using SystemServices;
using UserService;

namespace EduApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterRepository.Register(services);
            RegisterCodeBookService.RegistrationCodeBook(services);
            RegisterOrganizationService.RegisterService(services);
            RegisterUserService.RegisterService(services);
            RegisterSystemService.RegisterService(services);
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<EduDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PublicApi"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowInternal", builder => builder.SetIsOriginAllowed(IsOriginAllowed).AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services
                .AddApiVersioning(config =>
                {
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.AssumeDefaultVersionWhenUnspecified = false;
                    config.ReportApiVersions = false;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Public", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal public", Version = "v1" });
                c.DocInclusionPredicate(
                    (docName, apiDesc) =>
                    {
                        var actionApiDescription = apiDesc.ActionDescriptor.EndpointMetadata.OfType<ApiExplorerSettingsAttribute>().FirstOrDefault();
                        if (actionApiDescription == null)
                        {
                            return false;
                        }

                        return actionApiDescription.GroupName == docName;
                    }
                );
                c.UseInlineDefinitionsForEnums();
                c.OperationFilter<SwaggerDefaultValues>();
                c.OperationFilter<AddRequiredHeaderParameter>();

            });

            /*services.AddHangfire(opt =>
            {
                opt.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"))
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings();
            });
            services.AddHangfireServer();*/
        }

        private bool IsOriginAllowed(string host)
        {
            var corsOriginAllowed = new[] { "http://localhost:3000", "https://app.flexiblelms.com", "https://wwww.flexiblelms.com" };
            return corsOriginAllowed.Contains(host);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // AFAIK in netcoreapp2.2 this was not required
            // to use CORS with attributes.
            // This is now required, as otherwise a runtime exception is thrown
            // UseCors applies a global CORS policy, when no policy name is given
            // the default CORS policy is applied
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "FlexibleLMS";
                c.SwaggerEndpoint("/swagger/Public/swagger.json", "FlexibleLMS API V1 - internal public");
                c.RoutePrefix = "swagger";
            });

            /* app.UseHangfireDashboard(
                    "/hangfire",
                    new DashboardOptions
                    {
                        Authorization = new[]
                        {
                            new BasicAuthAuthorizationFilter(
                                new BasicAuthAuthorizationFilterOptions
                                {
                                    SslRedirect = false,
                                    RequireSsl = false,
                                    LoginCaseSensitive = true,
                                    Users = new[]
                                    {
                                        new BasicAuthAuthorizationUser
                                        {
                                            Login = Configuration.GetSection("Hangfire").GetValue<string>("userName"),
                                            PasswordClear = Configuration.GetSection("Hangfire").GetValue<string>("userPassword")
                                        }
                                    }
                                }
                            )
                        }
                    }
                );*/
            /*var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var jobActivator = new ScopedJobActivator(serviceScopeFactory);
            GlobalConfiguration.Configuration.UseActivator(jobActivator);
            RecurringJob.AddOrUpdate<SendEmailJob>(job => job.Execute(), Cron.Minutely);*/
        }


    }
}
