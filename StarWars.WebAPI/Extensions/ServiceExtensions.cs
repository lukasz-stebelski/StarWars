using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StarWars.WebAPI.ApiKey;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
namespace StarWars.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarWars API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition(name: "ApiKey", new OpenApiSecurityScheme
                {
                    Description = "Enter 'ApiKey <token>' in the text input below.\r\n\r\nExample: 'ApiKey 12345abcdef'",
                    Name = ApiKeyAuthAttribute.ApiKeyHeaderName,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKey"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },
                            Scheme = "oauth2",
                            Name = "ApiKey",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
            });
            });
        }
    }
}
