using Core.State;
using Zenject;

namespace Core.Installers
{
    public class DayStateInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DayStateController>().AsSingle();
            //Container.BindExecutionOrder<DayStateController>(-10);
        }
    }
}