public interface IHealth
{
    public float GetMaxHealth();
    public void ChangeHealth(float amountToChange);
    public float GetCurrentHealth();

    public void ResetHealth();
}
