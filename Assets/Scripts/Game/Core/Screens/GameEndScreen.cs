using System.Threading.Tasks;
using Game.Core.Navigation;

namespace Game.Core.Screens
{
    public class GameEndScreen : BaseScreen
    {
        public async override void OpenScreen()
        {
            await Task.Delay(2000);
            
            OpenLeaderboardsScreen();
        }

        private void OpenLeaderboardsScreen()
        {
            Navigation.NavigateTo(ScreenNames.LeaderboardScreen);
        }

        public override void CloseScreen()
        {
            
        }

        public override string Name => ScreenNames.GameEndScreen;
    }
}