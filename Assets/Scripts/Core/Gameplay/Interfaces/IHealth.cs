namespace Core.Gameplay.Interfaces
{
    public interface IHealth
    {
        float Value { get; set; }

        /// <returns>Returns true if value less or equals 0</returns>
        bool Decrease(float amount);
        void Heal(float amount);
    }
}
