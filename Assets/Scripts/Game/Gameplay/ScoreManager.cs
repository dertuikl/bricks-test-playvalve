using Game.Core.DataSave;
using UnityEngine;

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
            Debug.Log($"Score added: {userData.Score}");
        }

        public void ApplyMultiplier(float multiplier)
        {
            userData.SetScore((int)(userData.Score * multiplier));
            Debug.Log($"Score multiplied by {multiplier}: {userData.Score}");
        }
    }
}