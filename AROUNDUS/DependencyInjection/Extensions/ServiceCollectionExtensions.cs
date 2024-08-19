namespace AROUNDUS.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
        }
    }
}
