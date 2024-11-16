using Game.Core.Navigation;
using Zenject;

public class RootInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<NavigationStateMachine>().FromComponentsInHierarchy().AsSingle().NonLazy();
    }
}