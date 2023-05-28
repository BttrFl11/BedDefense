namespace Core.Gameplay.Interfaces
{
    public interface IHealth
    {
        /// <returns> Returns true if value less or equals 0 </returns>
        bool Decrease(float amount);
        void Heal(float amount);
    }
}
