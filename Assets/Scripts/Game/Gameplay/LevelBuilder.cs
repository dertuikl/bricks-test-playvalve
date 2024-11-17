using Game.LevelsManagement;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class LevelBuilder : MonoBehaviour
    {
        private Camera mainCamera;
    
        [Inject]
        public void Construct(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }
        
        private void Awake()
        {
            SetupGridBounds();
        }
    
        private void SetupGridBounds()
        {
            var screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Debug.Log("Setup Grid Bounds");
        }
    
        public void BuildLevel(LevelConfig config)
        {
            Debug.Log($"Building Level {config.Level}");
        }
    }
}
