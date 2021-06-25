﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using Portfolio.Logic.Interfaces;
using Portfolio.ML_Models.Data;
using System;

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
        public ActionResult AnalyzeText([FromBody] string text)
        {
            if(text == null)
            {
                return BadRequest("Invalid text to analyze");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest("Model state is invalid");
            }

            return Ok(_sentimentAnalysisLogic.AnalyzeText(text));
        }
    }
}
