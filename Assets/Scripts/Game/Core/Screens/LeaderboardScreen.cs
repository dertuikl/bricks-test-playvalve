namespace Game.Core.Screens
{
    public class LeaderboardScreen : BaseScreen
    {
        public override void OpenScreen()
        {
            
        }

        public override void OnClickCloseButton()
        {
            Navigation.NavigateTo(ScreenNames.LobbyScreen);
        }

        public override void CloseScreen()
        {
            
        }

        public override string Name => ScreenNames.LeaderboardScreen;
    }
}