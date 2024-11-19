namespace Game.Core.DataSave
{
    public interface IUserData
    {
        public int BestScore { get; }
        public string LeaderboardSeed { get; }
    }
}