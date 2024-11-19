namespace Game.Gameplay
{
    public interface IScoreManager
    {
        int CurrentScore { get; }
        void AddScore(int scoreToAdd);
        void ApplyMultiplier(float multiplier);
        void SaveScore();
        void ResetScore();
    }
}