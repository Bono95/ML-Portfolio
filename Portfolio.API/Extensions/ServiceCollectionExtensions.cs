using Microsoft.Extensions.DependencyInjection;
using Portfolio.Logic.Extensions;
using Portfolio.ML_Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPortfolioServices(this IServiceCollection services)
        {
            services.AddPredictiveModels();

            services.AddBusinessDependencies();

            return services;
        }
    }
}
