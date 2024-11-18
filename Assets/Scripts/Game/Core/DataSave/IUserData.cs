namespace Game.Core.DataSave
{
    public interface IUserData
    {
        public int Score { get; }
        public int BestScore { get; }
        public string LeaderboardSeed { get; }
    }
}