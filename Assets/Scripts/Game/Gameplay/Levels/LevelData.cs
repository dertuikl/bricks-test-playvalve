using UnityEngine;

namespace Game.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Create LevelData", fileName = "LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField]
        private LevelsData allLevelsData;

        [SerializeField]
        [Multiline(20)]
        public string BricksMap = "123\n" + "333\n" + "444\n" + "555\n" + "123\n";

        private void OnValidate()
        {
            allLevelsData.Register(this);
        }
    }
}