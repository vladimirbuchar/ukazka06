using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EduApi.Configuration.Swagger
{
    public class RemoveAuthorizationFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (context.DocumentName == "Public" || context.DocumentName == "ExternalPublic" || context.DocumentName == "Setup")
            {
                swaggerDoc.Components.SecuritySchemes.Clear();
            }
        }
    }
}
