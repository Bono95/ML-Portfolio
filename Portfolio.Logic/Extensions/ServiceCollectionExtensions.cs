using Microsoft.Extensions.DependencyInjection;
using Portfolio.Logic.Interfaces;

namespace Portfolio.Logic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISentimentAnalysisLogic, SentimentAnalysisLogic>();

            return services;
        }
    }
}
