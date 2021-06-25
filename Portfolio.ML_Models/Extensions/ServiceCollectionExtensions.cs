using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Portfolio.ML_Models.Data;
using System.IO;
using System.Reflection;

namespace Portfolio.ML_Models.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPredictiveModels(this IServiceCollection services)
        {
            services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
                .FromFile(modelName: "SentimentAnalysisModel", filePath: "../Portfolio.ML_Models/Models/sentiment_model.zip", watchForChanges: true);

            return services;
        }
    }
}
