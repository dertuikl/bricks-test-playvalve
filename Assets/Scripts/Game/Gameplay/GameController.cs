using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameEndTrigger gameEndTrigger;
        
        public event Action GameEnd;
        
        private UserInputController userInputController;
        private IGameEvents gameEvents;
        private IScoreManager scoreManager;
        private int activeBalls;
        
        [Inject]
        public void Construct(UserInputController userInputController,
            IGameEvents gameEvents,
            IScoreManager scoreManager)
        {
            this.userInputController = userInputController;
            this.gameEvents = gameEvents;
            this.scoreManager = scoreManager;
        }

        private void Start()
        {
            userInputController.PointerUp += StartGame;
            gameEvents.BallSpawned += OnBallSpawned;
            
            scoreManager.ResetScore();
        }

        private void StartGame(Vector2 direction)
        {
            gameEndTrigger.BallEnteredTrigger += OnBallEnteredGameEndTrigger;
        }

        private void OnBallSpawned()
        {
            activeBalls++;
        }

        private void OnBallEnteredGameEndTrigger()
        {
            activeBalls--;
            
            if (activeBalls <= 0) {
                GameOver();
            }
        }
        
        private void GameOver()
        {
            gameEndTrigger.BallEnteredTrigger -= OnBallEnteredGameEndTrigger;
            GameEnd?.Invoke();
        }

        private void OnDestroy()
        {
            userInputController.PointerUp += StartGame;
            gameEvents.BallSpawned += OnBallSpawned;
            gameEndTrigger.BallEnteredTrigger += OnBallEnteredGameEndTrigger;
        }
    }
}