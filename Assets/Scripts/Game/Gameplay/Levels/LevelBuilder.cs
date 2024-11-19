using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Levels
{
    public class LevelBuilder : MonoBehaviour
    {
        [SerializeField]
        private LevelsData levelsData;

        [SerializeField]
        private BrickLevelData[] brickMap;
        
        private Camera mainCamera;

        /// <summary>
        /// Returns amount of bricks spawned in current level
        /// </summary>
        public event Action<int> LevelBuildingFinished;

        [Inject]
        public void Construct(Camera mainCamera)
        {
            this.mainCamera = mainCamera;
        }

        public void SetupLevel()
        {
            BuildLevel(levelsData.GetNextLevel());
        }

        private void BuildLevel(LevelData levelData)
        {
            var screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            var screenOrigin = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

            var totalWidth = screenBounds.x - screenOrigin.x;
            var totalHeight = screenBounds.y - 0;

            var rows = levelData.BricksMap.Split('\n').Reverse().ToArray();
            var numRows = rows.Length;
            var numCols = rows[0].Length;

            var brickWidth = totalWidth / numCols;
            var brickHeight = totalHeight / numRows;

            var startY = 0;
            var bricksCount = 0;

            for (var row = 0; row < numRows; row++) {
                for (var col = 0; col < numCols; col++) {
                    var brickIdChar = rows[row][col].ToString();
                    if (!int.TryParse(brickIdChar, out var brickId)) {
                        Debug.LogError($"Invalid brick ID {brickId}");
                        continue;
                    }
                    
                    var brickData = brickMap.FirstOrDefault(b => b.BrickId == brickId);
                    if (brickData == null || brickData.Brick == null) {
                        continue;
                    }
                    var x = screenOrigin.x + col * brickWidth + brickWidth / 2;
                    var y = startY + row * brickHeight + brickHeight / 2;

                    var brickInstance = Instantiate(brickData.Brick, transform);
                    brickInstance.transform.position = new Vector3(x, y, 0);
                    brickInstance.transform.localScale = new Vector3(brickWidth * 0.95f, brickHeight * 0.95f, 1);
                    bricksCount++;
                }
            }
            
            LevelBuildingFinished?.Invoke(bricksCount);
        }
    }
}