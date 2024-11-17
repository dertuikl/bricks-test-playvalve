using Game.LevelsManagement;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private LevelBuilder levelBuilder;
        
        private ILevelConfigProvider configProvider;
        
        [Inject]
        public void Construct(ILevelConfigProvider configProvider)
        {
            this.configProvider = configProvider;
        }
        
        public void SetupLevel()
        {
            var levelConfig = configProvider.GetLevelConfig();
            levelBuilder.BuildLevel(levelConfig);
        }
    }
}