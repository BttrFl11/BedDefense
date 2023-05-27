namespace Core.Gameplay.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        void Destroy();
    }
}
