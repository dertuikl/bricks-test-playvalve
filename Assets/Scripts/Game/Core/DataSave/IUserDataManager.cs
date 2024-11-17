namespace Game.Core.DataSave
{
    public interface IUserDataManager : IUserData
    {
        void SetLogsEnabled(bool logsEnabled);
        void SetLevel(int level);
        void SetScore(int score);
    }
}