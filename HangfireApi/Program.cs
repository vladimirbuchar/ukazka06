
using Hangfire;
using HangfireApi.Configuration.Hangfire;
using HangfireService;
using Integration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
ConfigureServices(builder.Services);

WebApplication app = builder.Build();
Configure(app, app.Environment);

app.Run();
void ConfigureServices(IServiceCollection services)
{
    RegisterRepository.Register(services);
    RegisterIntegration.Register(services);

    _ = services
        .AddMvc(options =>
        {
            options.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
            options.Filters.Add(new ProducesAttribute("application/json"));
        })
        .SetCompatibilityVersion(CompatibilityVersion.Latest);
    _ = services.AddDbContext<EduDbContext>(options =>
    {
        _ = options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        _ = options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });



    _ = services.AddControllers();
    _ = services.AddHangfire(opt =>
    {
        _ = opt.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"))
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings();
    });
    _ = services.AddHangfireServer();


}


void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    _ = app.UseRouting();
    _ = app.UseAuthentication();
    _ = app.UseAuthorization();

    // AFAIK in netcoreapp2.2 this was not required
    // to use CORS with attributes.
    // This is now required, as otherwise a runtime exception is thrown
    // UseCors applies a global CORS policy, when no policy name is given
    // the default CORS policy is applied
    _ = app.UseCors();

    if (env.IsDevelopment())
    {
        _ = app.UseDeveloperExceptionPage();
    }

    _ = app.UseHttpsRedirection();

    _ = app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllers();
    });

    _ = app.UseHangfireDashboard(
                "/hangfire",
                new DashboardOptions
                {
                    /*Authorization = new[]
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
                      }*/
                }
            );
    IServiceScopeFactory serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
    ScopedJobActivator jobActivator = new(serviceScopeFactory);
    _ = GlobalConfiguration.Configuration.UseActivator(jobActivator);
    RecurringJob.AddOrUpdate<SendEmailJob>(job => job.Execute(), Cron.Minutely);




}
