using Game;
using Game.Core;
using Game.Core.DataSave;
using Game.Core.Navigation;
using UnityEngine;
using Zenject;

public class RootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<NavigationStateMachine>().FromComponentsInHierarchy().AsSingle().NonLazy();
        Container.Bind<UserInputController>().FromComponentsInHierarchy().AsSingle();
        Container.BindInterfacesTo<UserData>().AsSingle();
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        Container.BindInterfacesTo<BallAnchorPointProvider>().AsSingle();
        Container.BindInterfacesTo<LevelConfigProvider>().AsSingle();
    }
}