using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

using System.Linq;

namespace Core.Base.Swagger
{
    // Custom operation filter to set default values for Swagger
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription apiDescription = context.ApiDescription;


            foreach (Microsoft.AspNetCore.Mvc.ApiExplorer.ApiResponseType responseType in context.ApiDescription.SupportedResponseTypes)
            {
                string responseKey = responseType.StatusCode.ToString();
                if (!operation.Responses.ContainsKey(responseKey))
                {
                    operation.Responses[responseKey] = new OpenApiResponse { Description = "Default" };
                }
            }

            foreach (OpenApiParameter parameter in operation.Parameters)
            {
                Microsoft.AspNetCore.Mvc.ApiExplorer.ApiParameterDescription description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                parameter.Description ??= description.ModelMetadata.Description;

                if (parameter.Schema.Default == null && description.DefaultValue != null)
                {
                    parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
                }

                parameter.Required = description.IsRequired;
            }
        }
    }
}
