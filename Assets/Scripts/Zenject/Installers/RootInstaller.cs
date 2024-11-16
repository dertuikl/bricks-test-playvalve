using Game.Core;
using Game.Core.DataSave;
using Game.Core.Navigation;
using Zenject;

public class RootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<NavigationStateMachine>().FromComponentsInHierarchy().AsSingle().NonLazy();
        Container.Bind<UserData>().AsSingle();
        Container.Bind<UserInputController>().FromComponentsInHierarchy().AsSingle();
    }
}