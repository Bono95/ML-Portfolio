using Microsoft.Extensions.ML;
using Portfolio.Logic.Interfaces;
using Portfolio.ML_Models.Data;
using System;

namespace Portfolio.Logic
{
    public class SentimentAnalysisLogic : ISentimentAnalysisLogic
    {
        private readonly PredictionEnginePool<SentimentData, SentimentPrediction> _predictionEnginePool;

        public SentimentAnalysisLogic(PredictionEnginePool<SentimentData, SentimentPrediction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        public string AnalyzeText(SentimentData data)
        {
            SentimentPrediction prediction = _predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: data);

            string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return sentiment;
        }
    }
}
