namespace Game.Core.Navigation
{
    public interface INavigation
    {
        /// <summary>
        /// Use ScreenNames naming constants.
        /// </summary>
        /// <param name="screenName"></param>
        public void NavigateTo(string screenName);
    }
}