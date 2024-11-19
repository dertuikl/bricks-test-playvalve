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
        private float autoScrollDurationRate = 0.5f;

        private ILeaderboardInfoGenerator leaderboardGenerator;
        private LeaderboardEntry playerEntry;

        public override string Name => ScreenNames.LeaderboardScreen;

        [Inject]
        public void Construct(ILeaderboardInfoGenerator leaderboardGenerator)
        {
            this.leaderboardGenerator = leaderboardGenerator;
        }

        private void Awake()
        {
            SetupLeaderboardView();
        }
        
        protected override void OnScreenOpen()
        {
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
            
            var playerRectTransform = playerEntry.GetComponent<RectTransform>();
            var playerPos = playerRectTransform.anchoredPosition.y + playerRectTransform.rect.height / 2;
            var initialNormalisedPos = scrollRect.normalizedPosition.y;
            var scrollRectDeltaHeight = scrollRect.content.rect.height - scrollRect.viewport.rect.height;
            var targetNormalisedPos = Math.Clamp(1 + playerPos / scrollRectDeltaHeight, 0, 1);
            var timePassed = 0f;
            var scrollTime = (1 - targetNormalisedPos) * autoScrollDurationRate;

            while (timePassed < scrollTime) {
                timePassed += Time.deltaTime;

                if (timePassed > scrollTime) {
                    timePassed = scrollTime;
                }

                var calculatedPos = Mathf.Lerp(initialNormalisedPos, targetNormalisedPos,
                    timePassed / scrollTime);
                scrollRect.verticalNormalizedPosition = calculatedPos;

                yield return null;
            }

            scrollRect.verticalNormalizedPosition = targetNormalisedPos;
        }
    }
}