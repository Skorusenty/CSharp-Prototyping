using System.Reflection;
using SurvivalPrototype.Entities;

namespace SurvivalPrototype.Systems;

public static class InventorySystem
{
    

    public static void AddItem(Player player, string itemName, int quantity)
    {
        if(player.Inventory.ContainsKey(itemName))
        {
            player.Inventory[itemName] += quantity;        
        } else
        {
            player.Inventory[itemName] = quantity;
        }
    }
}