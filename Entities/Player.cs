namespace SurvivalPrototype.Entities;

public class Player
{
    public int Health { get; private set; } = 100;
    public int Damage { get; private set; } = 10;
    public int Experience { get; private set; } = 0;
    public int Level { get; private set; } = 1;
    public int Hunger { get; private set; } = 100;
    public int Stamina { get; private set; } = 100;
    public int ExpToNextLevel { get; private set;} = 100;
    public double GameScale { get; private set;} = 1.05; 

    public Dictionary<string, int> Inventory = new Dictionary<string, int>();

    public void TakeDamage(int dmg)
    {
        Health -= dmg;
        Console.WriteLine($"You take {dmg} damage. Remaining health: {Health}");
    }

public void HungerTick(Player player, int amount)
    {
        Hunger -= amount;
        Console.WriteLine($"You feel {amount}% hungrier. Current hunger: {Hunger}%");
    }

public void StaminaTick(Player player, int amount)
    {
        Stamina -= amount;
        Console.WriteLine($"You feel {amount}% more tired. Current stamina: {Stamina}%");
    }

public void Rest(Player player, int amount)
    {
        Stamina += amount;
        Health += (int)(5 * GameScale);
        if(Stamina > 100) Stamina = 100;
        if(Health > 100) Health = 100;

        Console.WriteLine($"You rested for countless hours... Your stamina is now {Stamina}%");
    }

public void Eat(Player player, int amount)
    {
        Hunger += amount;
        Health += (int)(5 * GameScale);
        if(Hunger > 100) Hunger = 100;
        if(Health > 100) Health = 100;
        Console.WriteLine($"You ate some food... Your hunger is now {Hunger}%");
    }

public void IncreaseExperience(Player player, int amount)
    {
        Experience += (int)(amount * GameScale);
        Console.WriteLine($"You gained {amount} experience. Exp needed for next Level: {ExpToNextLevel - Experience} ");
        CheckLvlUp();
    }

public void CheckLvlUp()
    {
        if(Experience >= ExpToNextLevel)
        {
            Level++;
            Experience -= ExpToNextLevel;
            ExpToNextLevel = (int)(ExpToNextLevel * GameScale);
            Health += (int)(10 * GameScale);
            Damage += (int)(2 * GameScale);
        }
    }

    public bool IsAlive()
    {
        return Health > 0 && Hunger > 0;
    }
}