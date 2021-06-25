using Portfolio.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Logic
{
    public class SentimentAnalysisLogic : ISentimentAnalysisLogic
    {
        public string AnalyzeText(string text)
        {
            return "That sounds bad, man.";
        }
    }
}
