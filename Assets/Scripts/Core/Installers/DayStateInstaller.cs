using Core.State;
using Core.State.States;
using Zenject;

namespace Core.Installers
{
    public class DayStateInstaller : MonoInstaller
    {
        private DayStateController _controller;

        public override void InstallBindings()
        {
            _controller = new DayStateController();
            Container.Bind<DayStateController>().FromInstance(_controller).AsSingle();

            AddStates();
        }

        private void AddStates()
        {
            _controller.Add<DayState_Morning>();
            _controller.Add<DayState_Night>();
        }

        private void Update()
        {
            _controller.Update();
        }
    }
}