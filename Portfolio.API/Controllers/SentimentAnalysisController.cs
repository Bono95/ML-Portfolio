using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using Portfolio.Data;
using Portfolio.Logic.Interfaces;
using System;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentAnalysisController : ControllerBase
    {
        //private readonly ISentimentAnalysisLogic _sentimentAnalysisLogic;
        private readonly PredictionEnginePool<SentimentData, SentimentPrediction> _predictionEnginePool;

        public SentimentAnalysisController(ISentimentAnalysisLogic sentimentAnalysisLogic, PredictionEnginePool<SentimentData, SentimentPrediction> predictionEnginePool)
        {
            //_sentimentAnalysisLogic = sentimentAnalysisLogic;
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult AnalyzeText([FromBody] string text)
        {
            SentimentData data = new SentimentData
            {
                SentimentText = text
            };

            if(text == null)
            {
                return BadRequest("Invalid text to analyze");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            SentimentPrediction prediction = _predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: data);

            string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return Ok(sentiment);
        }
    }
}
