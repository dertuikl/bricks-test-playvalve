using System;
using System.Threading.Tasks;
using Game.Gameplay;
using UnityEngine;

namespace Game.Core.Screens
{
    public class GameScreen : AnimatedScreen
    {
        [SerializeField]
        private GameController gameControllerPrefab;
        
        private GameController gameController;

        private void Awake()
        {
            gameController = Instantiate(gameControllerPrefab);
            gameController.GameEnd += ProcessGameEnd;
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