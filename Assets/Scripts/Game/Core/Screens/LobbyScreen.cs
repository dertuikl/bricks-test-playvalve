using System;
using System.Threading.Tasks;
using Game.Core.Navigation;
using UnityEngine;

namespace Game.Core.Screens
{
    public class LobbyScreen : BaseScreen
    {
        public override void OpenScreen()
        {
            
        }

        public void OnClickStartGameButton()
        {
            Navigation.NavigateTo(ScreenNames.GameScreen);
        }

        public void OnClickLeaderboardButton()
        {
            Navigation.NavigateTo(ScreenNames.LeaderboardScreen);
        }
        
        public override void CloseScreen()
        {
            
        }

        public override string Name => ScreenNames.LobbyScreen;
    }
}