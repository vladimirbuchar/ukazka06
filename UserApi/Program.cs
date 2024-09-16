using Asp.Versioning;
using Core.Base.Swagger;
using Core.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model;
using Repository;
using System.Security.Claims;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
ConfigureServices(builder.Services);

WebApplication app = builder.Build();
Configure(app, app.Environment);

app.Run();
void ConfigureServices(IServiceCollection services)
{
    RegisterRepository.Register(services);

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
    // Configure JWT authentication

    byte[] key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JWTKey"));

    _ = services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
                    return kid == Configuration.GetValue<string>("JWTKid")
                        ? (new[] { new SymmetricSecurityKey(key) })
                        : throw new SecurityTokenInvalidSigningKeyException("Invalid key identifier.");
                }
            };
        });

    _ = services.AddAuthorization(options =>
    {
        options.AddPolicy("ClientPolicy", policy => policy.RequireClaim(ClaimTypes.Role, UserRole.REGISTERED_USER));
    });
    ;

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

        c.SwaggerDoc("User", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "FlexibleLMS - user", Version = "v1" });
        c.DocInclusionPredicate(
            (docName, apiDesc) =>
            {
                ApiExplorerSettingsAttribute? actionApiDescription = apiDesc.ActionDescriptor.EndpointMetadata.OfType<ApiExplorerSettingsAttribute>().FirstOrDefault();
                return actionApiDescription != null && actionApiDescription.GroupName == docName;
            }
        );
        c.UseInlineDefinitionsForEnums();

        c.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field"
            }
        );

        c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            Array.Empty<string>()
                        }
            }
        );
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
        c.SwaggerEndpoint("/swagger/User/swagger.json", "FlexibleLMS API V1 - user");
        c.RoutePrefix = "swagger";
    });



}
