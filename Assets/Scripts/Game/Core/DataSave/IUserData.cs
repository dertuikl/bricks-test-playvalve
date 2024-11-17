namespace Game.Core.DataSave
{
    public interface IUserData
    {
        public bool LogsEnabled { get; }
        public int Level { get; }
        public int Score { get; }
    }
}