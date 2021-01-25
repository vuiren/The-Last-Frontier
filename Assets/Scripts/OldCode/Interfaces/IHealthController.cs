public interface IHealthController
{
    void TakeDamage(int damageCount);
    void TakeHeal(int healCount);
    bool HealingRequired();
}
