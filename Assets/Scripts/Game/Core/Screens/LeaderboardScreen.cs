namespace Game.Core.Screens
{
    public class LeaderboardScreen : AnimatedScreen
    {
        public void OnClickCloseButton()
        {
            Navigation.NavigateTo(ScreenNames.LobbyScreen);
        }

        public override string Name => ScreenNames.LeaderboardScreen;
    }
}