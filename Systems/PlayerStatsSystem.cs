using SurvivalPrototype.Entities;


namespace SurvivalPrototype.Systems;

public static class PlayerStatsSystem
{
    public static void DecreaseHunger(Player player, int amount)
    {
        player.HungerTick(player, amount);
    }

    public static void DecreaseStamina(Player player, int amount)
    {
        player.StaminaTick(player, amount);
    }

    public static void IncreaseStamina(Player player, int amount)
    {
        player.Rest(player, amount);
    }

    public static void IncreaseHunger(Player player, int amount)
    {
        player.Eat(player, amount);
    }

    public static void GainExperience(Player player, int amount)
    {
        amount = (int)(player.GameScale * amount);
        player.IncreaseExperience(player, amount);
    }
}