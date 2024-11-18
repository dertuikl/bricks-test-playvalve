using Game.Core.DataSave;
using UnityEngine;
using Zenject;

namespace Game.Core.Screens
{
    public class LobbyScreen : AnimatedScreen
    {
        [SerializeField]
        private IUserDataManager userDataManager;

        [Inject]
        public void Construct(IUserDataManager userDataManager)
        {
            this.userDataManager = userDataManager;
        }
        
        public void OnClickStartGameButton()
        {
            Navigation.NavigateTo(ScreenNames.GameScreen);
        }

        public void OnClickLeaderboardButton()
        {
            Navigation.NavigateTo(ScreenNames.LeaderboardScreen);
        }

        public void OnClickClearDataButton()
        {
            userDataManager.ClearAllData();
        }
        
        public override string Name => ScreenNames.LobbyScreen;
    }
}