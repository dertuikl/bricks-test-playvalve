using System.Threading.Tasks;
using Game.Core.Navigation;
using UnityEngine;
using Zenject;

namespace Game.Core.Screens
{
    public abstract class BaseScreen : MonoBehaviour, IScreen
    {
        protected INavigation Navigation;
        
        [Inject]
        public void Construct(INavigation navigation)
        {
            Navigation = navigation;
        }
        
        public abstract Task OpenScreen();

        public abstract Task CloseScreen();
        
        public abstract string Name { get; }
    }
}