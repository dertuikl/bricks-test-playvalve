namespace Game.Core.DataSave
{
    public interface IUserDataManager : IUserData
    {
        int Score { get; }
        void SetScore(int score);
        void SetBestScore(int bestScore);
        void ClearAllData();
    }
}