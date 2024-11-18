using UnityEngine;

namespace Game.Core.DataSave
{
    public class UserData : IUserDataManager, IDebugState
    {
        private const string LogsKey = "logs_enabled";
        private const string ScoreKey = "score";
        private const string BestScoreKey = "best_score";

        public bool LogsEnabled => PlayerPrefs.GetInt(LogsKey, 0) == 1;
        public int Score => PlayerPrefs.GetInt(ScoreKey, 0);
        public int BestScore => PlayerPrefs.GetInt(BestScoreKey, 0);
        
        public void SetLogsEnabled(bool logsEnabled) => PlayerPrefs.SetInt(LogsKey, logsEnabled ? 1 : 0);
        public void SetScore(int score) => PlayerPrefs.SetInt(ScoreKey, score);
        public void SetBestScore(int bestScore) => PlayerPrefs.SetInt(BestScoreKey, bestScore);
    }
}