namespace Core.State.States
{
    public interface IState
    {
        void _Enter();
        void _Exit();
        void _Update();
    }
}