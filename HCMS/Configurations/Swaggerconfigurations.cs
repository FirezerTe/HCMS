using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace HCMS.API.Configurations
{
    public static class Swaggerconfigurations
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "HCMS Api", Version = "v1" });
                opt.CustomOperationIds(options => $"{options.ActionDescriptor.RouteValues["action"]}");
                opt.DescribeAllParametersInCamelCase();
                opt.OrderActionsBy(x => x.RelativePath);
                opt.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                opt.OperationFilter<SecurityRequirementsOperationFilter>();
                opt.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            });

            return services;
        }
    }
}
