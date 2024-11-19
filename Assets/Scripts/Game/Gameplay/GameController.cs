using System;
using Game.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameEndTrigger gameEndTrigger;
        
        [SerializeField]
        private LevelBuilder levelBuilder;
        
        private UserInputController userInputController;
        private IGameEvents gameEvents;
        private IGameEventsInvoker gameEventsInvoker;
        private IScoreManager scoreManager;
        private int activeBalls;
        private int activeBricks;
        
        [Inject]
        public void Construct(UserInputController userInputController,
            IGameEvents gameEvents,
            IGameEventsInvoker gameEventsInvoker,
            IScoreManager scoreManager)
        {
            this.userInputController = userInputController;
            this.gameEvents = gameEvents;
            this.gameEventsInvoker = gameEventsInvoker;
            this.scoreManager = scoreManager;
        }

        private void Start()
        {
            userInputController.PointerUp += StartGame;
            gameEvents.BrickDestroyed += OnBrickDestroyed;
            gameEvents.BallSpawned += OnBallSpawned;
            
            scoreManager.ResetScore();
            levelBuilder.LevelBuildingFinished += amount => activeBricks = amount;
            levelBuilder.SetupLevel();
        }

        private void StartGame(Vector2 direction)
        {
            gameEndTrigger.BallEnteredTrigger += OnBallEnteredGameEndTrigger;
        }

        private void OnBrickDestroyed(Vector3 brickPosition)
        {
            activeBricks--;
        }
        
        private void OnBallSpawned()
        {
            activeBalls++;
        }

        private void OnBallEnteredGameEndTrigger()
        {
            activeBalls--;
            TryEndGame();
        }

        private void TryEndGame()
        {
            Debug.Log($"Balls {activeBalls}, Bricks {activeBricks}");
            if (activeBalls <= 0 || activeBricks <= 0) {
                GameOver();
            }
        }
        
        private void GameOver()
        {
            gameEndTrigger.BallEnteredTrigger -= OnBallEnteredGameEndTrigger;
            gameEventsInvoker.InvokeGameOver();
        }

        private void OnDestroy()
        {
            userInputController.PointerUp += StartGame;
            gameEvents.BallSpawned += OnBallSpawned;
            gameEndTrigger.BallEnteredTrigger += OnBallEnteredGameEndTrigger;
        }
    }
}