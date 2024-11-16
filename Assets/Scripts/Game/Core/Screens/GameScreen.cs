using System.Threading.Tasks;
using Game.Core.Navigation;

namespace Game.Core.Screens
{
    public class GameScreen : BaseScreen
    {
        public override void OpenScreen()
        {
            
        }

        private void ProcessGameEnd()
        {
            Navigation.NavigateTo(ScreenNames.GameEndScreen);
        }

        public override void CloseScreen()
        {
            
        }

        public override string Name => ScreenNames.GameScreen;
    }
}