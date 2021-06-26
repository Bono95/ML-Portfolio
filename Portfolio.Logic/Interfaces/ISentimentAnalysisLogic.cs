using Portfolio.ML_Models.Data;

namespace Portfolio.Logic.Interfaces
{
    public interface ISentimentAnalysisLogic
    {
        public string AnalyzeText(SentimentData data);
    }
}
