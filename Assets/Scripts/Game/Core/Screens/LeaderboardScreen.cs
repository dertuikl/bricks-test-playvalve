using System;
using System.Collections;
using Game.Core.DataSave;
using Game.UI.Leadedboard;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Core.Screens
{
    public class LeaderboardScreen : AnimatedScreen
    {
        [SerializeField]
        private ScrollRect scrollRect;

        [SerializeField]
        private RectTransform leaderboardEntriesContainer;

        [SerializeField]
        private LeaderboardEntry entryPrefab;

        [SerializeField]
        private float autoScrollDuration = 0.5f;

        private IUserData userData;
        private ILeaderboardInfoGenerator leaderboardGenerator;
        private LeaderboardEntry playerEntry;

        public override string Name => ScreenNames.LeaderboardScreen;

        [Inject]
        public void Construct(IUserData userData, ILeaderboardInfoGenerator leaderboardInfoGenerator)
        {
            this.userData = userData;
            this.leaderboardGenerator = leaderboardInfoGenerator;
        }

        public override void OpenScreen()
        {
            SetupLeaderboardView();
            StartCoroutine(AutoScrollToPlayerPosition());
        }

        public void OnClickNewGameButton()
        {
            Navigation.NavigateTo(ScreenNames.GameScreen);
        }

        public void OnClickCloseButton()
        {
            Navigation.NavigateTo(ScreenNames.LobbyScreen);
        }

        private void SetupLeaderboardView()
        {
            var infoArray = leaderboardGenerator.GenerateLeaderboardEntriesInfo();
            Array.Sort(infoArray, (a, b) => a.Score.CompareTo(b.Score) * -1);
            for (var i = 0; i < infoArray.Length; i++) {
                var entryInfo = infoArray[i];
                var entry = Instantiate(entryPrefab, scrollRect.content);
                entry.FillWithInfo(i + 1, entryInfo);
                if (entryInfo.IsPlayer) {
                    playerEntry = entry;
                }
            }
        }

        private IEnumerator AutoScrollToPlayerPosition()
        {
            yield return new WaitForEndOfFrame();

            scrollRect.onValueChanged.AddListener(a =>
            {
                Debug.Log($"{scrollRect.normalizedPosition}");
            });
            
            var playerRectTransform = playerEntry.GetComponent<RectTransform>();
            var playerPos = playerRectTransform.anchoredPosition.y - playerRectTransform.rect.height / 2;
            var initialNormalisedPos = scrollRect.normalizedPosition.y;
            var targetNormalisedPos = 1 + playerPos / scrollRect.content.rect.height;
            var timePassed = 0f;

            while (timePassed < autoScrollDuration) {
                timePassed += Time.deltaTime;

                if (timePassed > autoScrollDuration) {
                    timePassed = autoScrollDuration;
                }

                var calculatedPos = Mathf.Lerp(initialNormalisedPos, targetNormalisedPos,
                    timePassed / autoScrollDuration);
                scrollRect.verticalNormalizedPosition = calculatedPos;

                yield return null;
            }

            scrollRect.verticalNormalizedPosition = targetNormalisedPos;
        }
    }
}