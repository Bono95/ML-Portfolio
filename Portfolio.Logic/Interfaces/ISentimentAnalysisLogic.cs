using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Logic.Interfaces
{
    public interface ISentimentAnalysisLogic
    {
        public string AnalyzeText(string text);
    }
}
