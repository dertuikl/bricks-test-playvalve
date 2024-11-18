using System;
using Game.Core.DataSave;
using Game.UI.Leadedboard;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.Core.Screens
{
    public class LeaderboardScreen : AnimatedScreen
    {
        [SerializeField]
        private ScrollView scrollView;
        
        [SerializeField]
        private RectTransform leaderboardEntriesContainer;
        
        [SerializeField]
        private LeaderboardEntry entryPrefab;
        
        private IUserData userData;
        private ILeaderboardInfoGenerator leaderboardGenerator;

        public override string Name => ScreenNames.LeaderboardScreen;
        
        [Inject]
        public void Construct(IUserData userData,
        ILeaderboardInfoGenerator leaderboardInfoGenerator)
        {
            this.userData = userData;
            this.leaderboardGenerator = leaderboardInfoGenerator;
        }
        
        public override void OpenScreen()
        {
            Debug.Log($"Best score: {userData.BestScore}");
            SetupLeaderboardView();
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
                Instantiate(entryPrefab, leaderboardEntriesContainer).FillWithInfo(i + 1, entryInfo);
            }
        }
    }
}