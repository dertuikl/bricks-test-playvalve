using Game.Core.DataSave;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

namespace Game.Core.Screens
{
    public class LeaderboardScreen : AnimatedScreen
    {
        private IUserData userData;

        [Inject]
        public void Construct(IUserData userData)
        {
            this.userData = userData;
        }
        
        public override void OpenScreen()
        {
            Debug.Log($"Best score: {userData.BestScore}");
        }

        public void OnClickCloseButton()
        {
            Navigation.NavigateTo(ScreenNames.LobbyScreen);
        }

        public override string Name => ScreenNames.LeaderboardScreen;
    }
}