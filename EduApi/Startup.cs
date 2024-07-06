using Asp.Versioning;
using Core.Constants;
using EduApi.Configuration.Hangfire;
using EduApi.Configuration.Swagger;
using EduServices;
using EduServices.HangfireJob;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
            services.RegistrationCodeBook();
            services.RegistrationOrganizationCulture();
            services.RegistrationCourseTermDate();
            services.RegistrationStudentInGroup();
            services.RegistrationCourseTestEvaluation();
            services.RegisterEmail();
            services.RegistrationUser();
            services.RegistrationRole();
            services.RegistrationOrganizationRole();
            services.RegistrationOrganization();
            services.RegisterLicense();
            services.RegisterBranch();
            services.RegistrationCourse();
            services.RegistrationClassRoom();
            services.RegistrationCourseTerm();
            services.RegistrationCourseLector();
            services.RegistrionCourseStudent();
            services.RegistrationCourseLesson();
            services.RegistrationCourseLessonItem();
            services.RegistratioBankOfQuestion();
            services.RegistrationQuestion();
            services.RegistrationAnswer();
            services.RegisterNotification();
            services.RegisterFileUpload();
            services.RegisterTest();
            services.RegisterIntegration();
            services.RegisterPage();
            services.RegisterLifeTime();
            services.RegisterCertificate();
            services.RegisterPdf();
            services.RegisterSendMessage();
            services.RegisterStudentGroup();
            services.RegisterCourseMaterial();
            services.RegisterNote();
            services.RegisterCourseTable();
            services.RegisterChat();
            services.RegistrationIUserInOrganization();
            services.RegistrationOrganizationSetting();
            services.RegistrationOrganizationStudyHour();
            services.RegistrationOrganizationStudyHour();
            services.RegistrationAttendanceStudent();
            services.RegistrationCouseStudentMaterial();
            services.RegistrationStudentEvaluation();
            services.RegistrationStudentTestSummary();
            services.RegistrationStudentTestSummaryQuestion();
            services.RegistrationIStudentTestSummaryAnswer();
            services.RegistrationUserProfile();
            services.RegistrationRoute();
            services.RegistrationPermissions();
            services.RegistrationSetup();
            services.RegisterHangfireJob();
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
                    options.Filters.Add(new ProducesAttribute("application/json"));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<EduDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("EduApi"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowInternal", builder => builder.SetIsOriginAllowed(IsOriginAllowed).AllowAnyMethod().AllowAnyHeader());
            });
            // Configure JWT authentication

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JWTKey"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration.GetValue<string>("JWTIssuer"),
                        ValidAudience = Configuration.GetValue<string>("JWTAudience"),
                        IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
                        {
                            if (kid == Configuration.GetValue<string>("JWTKid"))
                            {
                                return new[] { new SymmetricSecurityKey(key) };
                            }
                            throw new SecurityTokenInvalidSigningKeyException("Invalid key identifier.");
                        }
                    };
                });

            services.AddAuthorization(options =>
        {
            options.AddPolicy("ClientPolicy", policy => policy.RequireClaim(ClaimTypes.Role, UserRole.REGISTERED_USER));
            options.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, UserRole.ADMINISTRATOR));
        }); ;

            services.AddControllers();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = false;
                config.ReportApiVersions = false;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Public", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal public", Version = "v1" });
                c.SwaggerDoc("ClientZone", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal course", Version = "v1" });
                c.SwaggerDoc("Organization", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal organization", Version = "v1" });
                c.SwaggerDoc("User", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal user", Version = "v1" });
                c.SwaggerDoc("StudyZone", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal study zone", Version = "v1" });
                c.SwaggerDoc("Codebook", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - internal codebook", Version = "v1" });
                c.SwaggerDoc("Admin", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - admin ", Version = "v1" });
                c.SwaggerDoc("Setup", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - setup ", Version = "v1" });
                c.SwaggerDoc("ExternalPublic", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external public", Version = "v1" });
                c.SwaggerDoc("ExternalClientZone", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external course", Version = "v1" });
                c.SwaggerDoc("ExternalOrganization", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external organization", Version = "v1" });
                c.SwaggerDoc("ExternalUser", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external user", Version = "v1" });
                c.SwaggerDoc("ExternalStudyZone", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external study zone", Version = "v1" });
                c.SwaggerDoc("ExternalCodebook", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - external codebook", Version = "v1" });

                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var actionApiDescription = apiDesc.ActionDescriptor.EndpointMetadata.OfType<ApiExplorerSettingsAttribute>().FirstOrDefault();
                    if (actionApiDescription == null)
                    {
                        return false;
                    }

                    return actionApiDescription.GroupName == docName;
                });
                c.UseInlineDefinitionsForEnums();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field"
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
                c.OperationFilter<SwaggerDefaultValues>();
                c.OperationFilter<AddRequiredHeaderParameter>();
                c.DocumentFilter<RemoveAuthorizationFilter>();

            });

            services.AddHangfire(opt =>
            {
                opt.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"))
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings();
            });
            services.AddHangfireServer();
        }

        private bool IsOriginAllowed(string host)
        {
            var corsOriginAllowed = new[] { "http://localhost:3000", "https://app.flexiblelms.com", "https://wwww.flexiblelms.com" };
            return corsOriginAllowed.Contains(host);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
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
                c.SwaggerEndpoint("/swagger/ClientZone/swagger.json", "FlexibleLMS API V1 - internal course");
                c.SwaggerEndpoint("/swagger/Organization/swagger.json", "FlexibleLMS API V1 - internal organization");
                c.SwaggerEndpoint("/swagger/User/swagger.json", "FlexibleLMS API V1 - internal user");
                c.SwaggerEndpoint("/swagger/StudyZone/swagger.json", "FlexibleLMS API V1 - internal study zone");
                c.SwaggerEndpoint("/swagger/Codebook/swagger.json", "FlexibleLMS API V1 - internal codebook");
                c.SwaggerEndpoint("/swagger/Admin/swagger.json", "FlexibleLMS API V1 - admin ");
                c.SwaggerEndpoint("/swagger/Setup/swagger.json", "FlexibleLMS API V1 - setup ");
                c.SwaggerEndpoint("/swagger/ExternalPublic/swagger.json", "FlexibleLMS API V1 - external public");
                c.SwaggerEndpoint("/swagger/ExternalClientZone/swagger.json", "FlexibleLMS API V1 - external course");
                c.SwaggerEndpoint("/swagger/ExternalStudyZone/swagger.json", "FlexibleLMS API V1 - external study zone");
                c.SwaggerEndpoint("/swagger/ExternalUser/swagger.json", "FlexibleLMS API V1 - external user");
                c.SwaggerEndpoint("/swagger/ExternalCodebook/swagger.json", "FlexibleLMS API V1 - external codebook");
                c.SwaggerEndpoint("/swagger/ExternalOrganization/swagger.json", "FlexibleLMS API V1 - external organization");
                c.RoutePrefix = "swagger";
            });

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[]
            {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
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
                    })
                }
            }
            );
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var jobActivator = new ScopedJobActivator(serviceScopeFactory);
            GlobalConfiguration.Configuration.UseActivator(jobActivator);
            RecurringJob.AddOrUpdate<SendEmailJob>(job => job.Execute(), Cron.Minutely);
        }
    }
}
