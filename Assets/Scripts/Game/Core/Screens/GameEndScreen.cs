using System.Collections;
using Game.Core.DataSave;
using Game.Gameplay;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core.Screens
{
    public class GameEndScreen : AnimatedScreen
    {
        [SerializeField]
        private TypeWriter gameOverTextTypeWriter;
        
        [SerializeField]
        private ScoreEndGameAnimation scoreEndGameAnimation;

        [SerializeField]
        private Button[] buttons;
        
        [SerializeField]
        private float delayBetweenButtonsShow = 0.2f;

        [SerializeField]
        private float closeDelay = 1.0f;
        
        private IScoreManager scoreManager;
        private IUserData userData;
        private bool screenCloseRequested;

        [Inject]
        public void Construct(IScoreManager scoreManager,
            IUserData userData)
        {
            this.scoreManager = scoreManager;
            this.userData = userData;
        }

        public override void OpenScreen()
        {
            StartCoroutine(ScreenAnimation());
        }

        private IEnumerator ScreenAnimation()
        {
            yield return gameOverTextTypeWriter.TypeWriterCoroutine();
            yield return scoreEndGameAnimation.ShowScoreAnimation(userData.Score, true);

            var delay = new WaitForSeconds(delayBetweenButtonsShow);
            foreach (var container in buttons) {
                container.gameObject.SetActive(true);
                yield return delay;
            }

            while (!screenCloseRequested) {
                yield return null;
            }

            var scoreForCloseAnimation = userData.Score;
            scoreManager.SaveAndResetScore();
            
            yield return scoreEndGameAnimation.ShowScoreAnimation(scoreForCloseAnimation);
            yield return new WaitForSeconds(closeDelay);
            OpenLeaderboardsScreen();
        }

        public void OnClickApplyMultiplierButton(int multiplierValue)
        {
            scoreManager.ApplyMultiplier(multiplierValue);
            foreach (var button in buttons) {
                button.interactable = false;
            }
            screenCloseRequested = true;
        }

        private void OpenLeaderboardsScreen()
        {
            Navigation.NavigateTo(ScreenNames.LeaderboardScreen);
        }

        public override string Name => ScreenNames.GameEndScreen;
    }
}