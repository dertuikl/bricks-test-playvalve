namespace Game.Core.DataSave
{
    public class UserData : IUserDataManager, IDebugState
    {
        public bool LogsEnabled { get; private set; } = false;
        public int Level { get; private set; } = 6;
        public int Score { get; private set; } = 0;
        
        public void SetLogsEnabled(bool logsEnabled) => LogsEnabled = logsEnabled;
        public void SetLevel(int level) => Level = level;
        public void SetScore(int score) => Score = score;
    }
}