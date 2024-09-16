using AdminService;
using Asp.Versioning;
using Core.Base.Swagger;
using Integration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Model;
using OrganizationService;
using Repository;
using SetupService;
using UserService;

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
    RegisterAdminService.RegisterService(services);
    RegisterSetupService.RegisterService(services);
    RegisterOrganizationService.RegisterService(services);
    RegisterUserService.RegisterService(services);

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

    _ = services.AddCors(options =>
    {
        options.AddPolicy("AllowInternal", builder => builder.SetIsOriginAllowed(IsOriginAllowed).AllowAnyMethod().AllowAnyHeader());
    });



    _ = services.AddControllers();
    _ = services
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

    _ = services.AddSwaggerGen(c =>
    {

        c.SwaggerDoc("Setup", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - setup ", Version = "v1" });
        c.DocInclusionPredicate(
            (docName, apiDesc) =>
            {
                ApiExplorerSettingsAttribute? actionApiDescription = apiDesc.ActionDescriptor.EndpointMetadata.OfType<ApiExplorerSettingsAttribute>().FirstOrDefault();
                return actionApiDescription != null && actionApiDescription.GroupName == docName;
            }
        );
        c.UseInlineDefinitionsForEnums();
        c.OperationFilter<SwaggerDefaultValues>();
        c.OperationFilter<AddRequiredHeaderParameter>();

    });

}
bool IsOriginAllowed(string host)
{
    string[] corsOriginAllowed = ["http://localhost:3000", "https://app.flexiblelms.com", "https://wwww.flexiblelms.com"];
    return corsOriginAllowed.Contains(host);
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
        IdentityModelEventSource.ShowPII = true;
    }

    _ = app.UseHttpsRedirection();

    _ = app.UseEndpoints(endpoints =>
    {
        _ = endpoints.MapControllers();
    });

    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "FlexibleLMS";
        c.SwaggerEndpoint("/swagger/Setup/swagger.json", "FlexibleLMS API V1 - setup ");
        c.RoutePrefix = "swagger";
    });



}
