namespace Game.Core.Screens
{
    public class LobbyScreen : AnimatedScreen
    {
        public void OnClickStartGameButton()
        {
            Navigation.NavigateTo(ScreenNames.GameScreen);
        }

        public void OnClickLeaderboardButton()
        {
            Navigation.NavigateTo(ScreenNames.LeaderboardScreen);
        }
        
        public override string Name => ScreenNames.LobbyScreen;
    }
}