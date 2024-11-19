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
        private int activeBalls;
        
        [Inject]
        public void Construct(UserInputController userInputController,
            IGameEvents gameEvents)
        {
            this.userInputController = userInputController;
            this.gameEvents = gameEvents;
        }

        private void Start()
        {
            userInputController.PointerUp += StartGame;
            gameEvents.BallSpawned += OnBallSpawned;
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