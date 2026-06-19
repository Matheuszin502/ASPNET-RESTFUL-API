using Microsoft.OpenApi.Models;

namespace RestWithASPNET.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "RESTFUL API ASP Dot Net Core";
        private static readonly string AppDescription = $"API RESTFUL feita em ASP Dot Net Core";

        public static IServiceCollection AddSwaggerConfig(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppName,
                    Version = "v1",
                    Description = AppDescription,
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    }
                });

                options.CustomSchemaIds(type => type.FullName);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSpecification(
            this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });
            return app;
        }
    }
}
