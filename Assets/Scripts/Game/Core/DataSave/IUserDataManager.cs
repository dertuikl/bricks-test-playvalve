namespace Game.Core.DataSave
{
    public interface IUserDataManager : IUserData
    {
        void SetLevel(int level);
        void SetScore(int score);
    }
}