namespace Game.Core.DataSave
{
    public interface IUserDataManager : IUserData
    {
        void SetScore(int score);
    }
}