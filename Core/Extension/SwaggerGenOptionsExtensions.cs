using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace Core.Extension
{
    public static class SwaggerGenOptionsExtensions
    {
        // Extension metoda pro SwaggerGenOptions
        public static void MapEnumType<TEnum>(this SwaggerGenOptions options, TEnum defaultValue)
            where TEnum : Enum
        {
            options.MapType<TEnum>(
                () => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(TEnum)).Select(name => new OpenApiString(name) as IOpenApiAny).ToList(),
                    Default = new OpenApiString(defaultValue.ToString())
                }
            );
        }
    }
}