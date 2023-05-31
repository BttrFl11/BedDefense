namespace Core.Gameplay.Interfaces
{
    public interface IDecelerate
    {
        void Decelerate(float amount);
        float GetSpeed();
    }
}
