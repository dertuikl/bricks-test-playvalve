namespace Game.Core.DataSave
{
    public interface IDebugState
    {
        bool LogsEnabled { get; }
        void SetLogsEnabled(bool logsEnabled);
    }
}