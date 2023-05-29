namespace Core.State.States
{
    public interface IDayState
    {
        void Enter();
        void Exit();
        void Update();
    }
}