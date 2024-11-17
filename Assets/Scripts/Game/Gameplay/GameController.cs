using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameEndTrigger gameEndTrigger;
        
        private UserInputController userInputController;
        
        public event Action RoundEnd;
        public event Action GameEnd;
        
        [Inject]
        public void Construct(UserInputController userInputController)
        {
            this.userInputController = userInputController;
        }

        private void Start()
        {
            userInputController.PointerUp += StartRound;
        }

        private void SetupBallPosition()
        {
            
        }

        private void StartRound(Vector2 direction)
        {
            gameEndTrigger.PlayerEnteredTrigger += EndRound;
        }

        private void EndRound()
        {
            gameEndTrigger.PlayerEnteredTrigger -= EndRound;
            RoundEnd?.Invoke();
            
            TryEndGame();
        }

        private void TryEndGame()
        {
            if (false) {
                // punishment (subtract 1 ball from queue)
                SetupBallPosition();
            } else {
                GameOver();
            }
        }
        
        private void GameOver()
        {
            GameEnd?.Invoke();
        }

        private void OnDestroy()
        {
            userInputController.PointerUp -= StartRound;
        }
    }
}