using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Create LevelsData", fileName = "LevelsData", order = 0)]
    public class LevelsData : ScriptableObject
    {
        [SerializeField]
        private List<LevelData> levels;

        private int levelIndex;

        public LevelData GetNextLevel()
        {
            var result = levels[levelIndex % levels.Count];
            levelIndex++;
            return result;
        }

        public void Register(LevelData levelData)
        {
            if (!levels.Contains(levelData)) {
                levels.Add(levelData);
            }
        }

        private void OnValidate()
        {
            levels.RemoveAll(l => l == null);
        }
    }
}