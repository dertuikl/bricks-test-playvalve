using Game.Core.DataSave;
using UnityEngine;

namespace Game
{
    public class LevelConfigProvider : ILevelConfigProvider
    {
        private IUserData userData;
        
        public LevelConfigProvider(IUserData userData)
        {
            this.userData = userData;
        }
        
        public LevelConfig GetLevelConfig()
        {
            Debug.Log("Create level config");
            return new LevelConfig(userData.Level);
        }
    }
}