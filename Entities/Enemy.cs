namespace SurvivalPrototype.Entities;

public class Enemy
{
    public int Health { get; private set; } = 50;
    public int Damage { get; private set; } = 5;
    public int ExperienceReward { get; private set; } = 20;

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        Console.WriteLine($"Enemy takes {dmg} damage. Remaining health: {Health}");
    }
    
    public bool IsAlive()
    {
        return Health > 0;
    }

}