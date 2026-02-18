using SurvivalPrototype.Entities;

namespace SurvivalPrototype.Systems;

public static class CombatSystem
{
    public static void PlayerAttack(Player player, Enemy enemy)
    {
        enemy.TakeDamage(player.Damage);
    }

    public static void EnemyAttack(Enemy enemy, Player player)
    {
        player.TakeDamage(enemy.Damage);
    }
}