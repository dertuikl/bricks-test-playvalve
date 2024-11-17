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
            Debug.Log(userData.Score);
        }
    }
}