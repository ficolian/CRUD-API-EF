using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Fish.Web.API.Core.Extension;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using FluentValidation.AspNetCore;
using Fish.Application.Usecase;

namespace Fish.Web.API.Core.Extension
{
    internal static class ServiceExtension
    {
        internal static void ConfigureMVC(this IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(c =>
                {
                    c.JsonSerializerOptions.WriteIndented = true;
                    c.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidation>()); //REGISTER REQUEST VALIDATION TO DEPENDENCY INJECTION CONTAINER
        }

        /// <summary>
        /// CORS configuration for IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //NOT ADVISEABLE FOR PRODUCTION
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        /// <summary>
        /// Swagger configuration for IServiceCollection
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("dev", new OpenApiInfo
                {
                    Title = "CUSTOMER REST API",
                    Version = $"DEV-{Environment.Version.Major}.{Environment.Version.Minor}.{DateTime.Now:yyyyMMddHHmmss}",
                    Description = "CUSTOMER Service REST API "
                });

                string xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
                c.IncludeXmlComments(xmlDocPath);

                
            });
        }
    }
}
