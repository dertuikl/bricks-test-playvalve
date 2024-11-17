using Game.Gameplay;
using UnityEngine;

namespace Game.Core.Screens
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        private GameController gameControllerPrefab;
        
        private GameController gameController;
        
        public override void OpenScreen()
        {
            gameController = Instantiate(gameControllerPrefab);
            gameController.SetupLevel();
        }

        private void ProcessGameEnd()
        {
            Navigation.NavigateTo(ScreenNames.GameEndScreen);
        }

        public override void CloseScreen()
        {
            Destroy(gameController.gameObject);
        }

        public override string Name => ScreenNames.GameScreen;
    }
}