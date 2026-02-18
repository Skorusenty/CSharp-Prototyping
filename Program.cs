using System.Security.Cryptography;
using SurvivalPrototype.Entities;
using SurvivalPrototype.Systems;

namespace SurvivalPrototype;

class Program
{
    static void Main(string[] args)
    {
        var player = new Player();
        var enemy = new Enemy();

        Console.WriteLine("Welcome to the Survival Prototype!");

        Console.WriteLine("What is your name, survivor?");
        string name = Console.ReadLine();
        Console.WriteLine($"Welcome, {name}! Your journey begins now.");
        
            while(player.IsAlive())
            {
                Console.WriteLine("What would you like to do? (F-Fight, R-Rest, E-Eat, Q-Quit, I-Inventory)");
                string input = Console.ReadLine().ToUpper();

                switch(input) 
                {
                    case "F":
                        Fight(player, enemy);
                        if(!enemy.IsAlive())
                        {
                            Console.WriteLine("A new enemy approaches!");
                            enemy = new Enemy();
                            PlayerStatsSystem.DecreaseHunger(player, 10);
                        }
                        break;
                    
                    case "R":
                        Rest(player);
                        break;
                
                    case "E":
                        Eat(player);
                        break;
                    
                    case "Q":
                        Console.WriteLine("Thanks for playing! Goodbye.");
                        return;
                    
                    case "I":
                        OpenInventory(player);
                        break;
                    
                    default:
                        Console.WriteLine("Invalid input. Please choose F, R, E, Q, or I.");
                        break;
                }

            Console.WriteLine($"Your stats - Health: {player.Health}, Hunger: {player.Hunger}%, Stamina: {player.Stamina}%, Experience: {player.Experience}/{player.ExpToNextLevel}");

            if(!enemy.IsAlive())
            {
                Console.WriteLine("You won!");
                
            }

            }
            
    }

    static void Fight(Player player, Enemy enemy)
    {
        Console.WriteLine($"You encounter an enemy! {enemy.Health} HP, {enemy.Damage} DMG.");
        while(player.IsAlive() && enemy.IsAlive())
        {
            Console.WriteLine("To perform attack, press any key...");
            Console.ReadKey();

            CombatSystem.PlayerAttack(player, enemy);
            PlayerStatsSystem.DecreaseStamina(player, 10);
            if(enemy.IsAlive()) 
            {
                CombatSystem.EnemyAttack(enemy, player);
            } else
            {
                Console.WriteLine("You defeated the enemy!");
                PlayerStatsSystem.GainExperience(player, enemy.ExperienceReward);
                InventorySystem.AddItem(player, "meat", 1);
            }
                        
        } 
    }

    static void Rest(Player player)
    {
        PlayerStatsSystem.IncreaseStamina(player, 20);
    }

    static void Eat(Player player)
    {
        PlayerStatsSystem.IncreaseHunger(player, 20);
    }

    static void OpenInventory(Player player)
    {
        Console.WriteLine("Inventory:");
         foreach(var item in player.Inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        
        Console.WriteLine("To use an item, type the name. To go back, type 'back'.");
        string input = Console.ReadLine();
        if(input.ToLower() == "back") 
        {
            return;
        } else if(player.Inventory.ContainsKey(input) && player.Inventory[input] > 0)
        {
            player.Inventory[input]--;
            Console.WriteLine($"You used one {input}.");
        }
    }
}
