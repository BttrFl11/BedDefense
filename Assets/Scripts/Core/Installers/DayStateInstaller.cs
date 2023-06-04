using Core.State;
using Core.State.States;
using Zenject;

namespace Core.Installers
{
    public class DayStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DayStateController>().AsSingle();

            Container.Bind<DayState_Morning>().AsSingle();
            Container.Bind<DayState_Night>().AsSingle();
        }
    }
}