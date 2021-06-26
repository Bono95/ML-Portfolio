using Microsoft.AspNetCore.Mvc;
using Portfolio.Logic.Interfaces;
using Portfolio.ML_Models.Data;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentAnalysisController : ControllerBase
    {
        private readonly ISentimentAnalysisLogic _sentimentAnalysisLogic;

        public SentimentAnalysisController(ISentimentAnalysisLogic sentimentAnalysisLogic)
        {
            _sentimentAnalysisLogic = sentimentAnalysisLogic;
        }

        [HttpPost]
        public ActionResult AnalyzeText([FromBody] SentimentData data)
        {
            if(data == null)
            {
                return BadRequest("Invalid text to analyze");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Ok(_sentimentAnalysisLogic.AnalyzeText(data));
        }
    }
}
