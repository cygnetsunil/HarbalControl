using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HC.API.Middleware
{
    public static class CoreMiddlewareExtention
    {
        /// <summary>
        /// Allow origins configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCoreMiddlewareExtention(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("AppSettings:AllowOrigins").Get<string>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", new CorsPolicy
                {
                    Origins = { allowedOrigins },
                    Headers = { "*" },
                    Methods = { "*" },
                    SupportsCredentials = false
                });
            });
            return services;
        }
        public static IApplicationBuilder UserCoresMiddleware(this IApplicationBuilder app) {
            return app.UseCors("AllowSpecificOrigin");
        }
    }
}
