using System;
using System.Threading;

namespace BattleArena
{
    class Program
    {
        static void Main(string[] args)
        {
        int stamina = 10;
        int panicLevel = 10;
        int enemyHealth = 10;
            Console.WriteLine("Welcome to the Battle Arean!");
            Console.WriteLine("Here are your starting stats:");
            DisplayHealthStats(stamina, panicLevel, enemyHealth);
            string play = GetUserInput("Are you ready to roll the dice? (y/n) ").ToLower();
            if (play == "y")
            {
                int rollCount = 0;
                while (rollCount <= 10)
                {
                    RollDie();
                    rollCount++;
                }
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int RollDie()
        {
            //The user has 10 rolls of the die to defeat the enemy. 
            Random diceRoll = new Random();
            return diceRoll.Next(1, 7); 
        }

        public void RollResult(int diceRoll, int stamina, int panicLevel, int enemyHealth)
        {
            if (diceRoll == 1)
            {
                Console.WriteLine("The user gets hit, and their panic level increases by 2");
                panicLevel = panicLevel + 2;
            }
            else if (diceRoll == 2)
            {
                Console.WriteLine("The user dodges the attack, but their stamina is reduced by 1");
                stamina--;
            }
            else if (diceRoll == 3)
            {
                Console.WriteLine("The user deflects the attack. There is no stat change");
            }
            else if (diceRoll == 4)
            {
                Console.WriteLine("The enemy backs away; the user’s stamina increases by 1");
                stamina++;
            }
            else if (diceRoll == 5)
            {
                Console.WriteLine("The enemy dodges, but the user strikes a glancing blow. The user’s panic is reduced by 1. The enemy loses 3 hit points.");
                panicLevel--;
                enemyHealth = enemyHealth - 3;
            }
            else if (diceRoll == 6)
            {
                Console.WriteLine("The enemy takes significant damage. The user’s panic is reduced by 3. Their stamina is increased by 2. The enemy loses 5 hit points.");
                panicLevel = panicLevel - 3;
                stamina = stamina + 2;
                enemyHealth = enemyHealth - 5;
            }
            DisplayHealthStats(stamina, panicLevel, enemyHealth);
        }

        public static void DisplayHealthStats(int stamina, int panicLevel, int enemyHealth)
        {
            Console.WriteLine($"STAMINA: {stamina}");
            Console.WriteLine($"PANIC LEVEL: {panicLevel}");
            Console.WriteLine($"ENEMY HEALTH: {enemyHealth}");
        }


        //Battle Results
        //After every roll, if the enemy has not died, the user’s panic increases by 1. Their stamina is reduced by 1. 
        //If the enemy has died, another enemy enters the arena.The player’s panic and stamina stay where it is. 
        //If the player has run out of turns, their panic reaches the max level.
        //If the player has died, the dream starts over from the beginning.
        public void BattleResults(int rollCount, int stamina, int panicLevel, int enemyHealth)
        {
            if (enemyHealth != 0)
            {
                panicLevel++;
                stamina--;
            }
            else if (enemyHealth == 0)
            {
                Console.WriteLine("You have defeated your enemy. However, another Enemy enters the arena.");
                Console.WriteLine("Prepare for another battle!");
            }
            else if (rollCount == 0)
            {
                panicLevel = 20;
            }
            else if (stamina == 0 || panicLevel == 0)
            {
                Console.WriteLine("You have died. The dream restarts and you are back in the Battle Arena!");
                //StartGame();
            }
        }

        //public void StartGame()
        //{

        //}
    }
                //Thread.Sleep(1000);
}

