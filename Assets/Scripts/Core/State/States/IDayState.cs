namespace Core.State.States
{
    public interface IDayState
    {
        void _Enter();
        void _Exit();
        void _Update();
    }
}