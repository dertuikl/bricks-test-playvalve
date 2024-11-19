using Game.Gameplay;
using UnityEngine;
using Zenject;

namespace Game.Core.Screens
{
    public class GameScreen : AnimatedScreen
    {
        [SerializeField]
        private GameController gameControllerPrefab;
        
        private IGameEvents gameEvents;
        private GameController gameController;

        [Inject]
        public void Construct(IGameEvents gameEvents)
        {
            this.gameEvents = gameEvents;
        }
        
        private void Awake()
        {
            gameController = Instantiate(gameControllerPrefab);
            gameEvents.GameOver += ProcessGameEnd;
        }

        private void ProcessGameEnd()
        {
            Navigation.NavigateTo(ScreenNames.GameEndScreen);
        }

        protected override void OnScreenClose()
        {
            Destroy(gameController.gameObject);
        }

        public override string Name => ScreenNames.GameScreen;
    }
}