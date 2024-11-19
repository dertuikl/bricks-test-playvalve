using Game.Core.DataSave;

namespace Game.Gameplay
{
    public class ScoreManager : IScoreManager
    {
        private readonly IUserDataManager userData;

        public ScoreManager(IUserDataManager userData)
        {
            this.userData = userData;
        }
        
        public void AddScore(int scoreToAdd)
        {
            userData.SetScore(userData.Score + scoreToAdd);
        }

        public void ApplyMultiplier(float multiplier)
        {
            userData.SetScore((int)(userData.Score * multiplier));
        }

        public void SaveAndResetScore()
        {
            if (userData.Score > userData.BestScore) {
                userData.SetBestScore(userData.Score);
            }

            userData.SetScore(0);
        }
    }
}