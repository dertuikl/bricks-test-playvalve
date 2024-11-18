using Game.Core.DataSave;
using Game.Core.Navigation;
using Game.Gameplay;
using UnityEngine;

namespace Zenject
{
    public class RootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NavigationStateMachine>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.Bind<UserInputController>().FromComponentsInHierarchy().AsTransient();
            Container.BindInterfacesTo<UserData>().AsSingle();
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
            Container.BindInterfacesTo<BallAnchorPointProvider>().AsSingle();
            Container.BindInterfacesTo<ScoreManager>().AsSingle();
        }
    }
}