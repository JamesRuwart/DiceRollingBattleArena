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

            int rollCount = 0;
            while (rollCount <= 10)
            {
                string play = GetUserInput("Are you ready to roll? (y/n) ").ToLower();
                if (play == "y")
                {

                    int rollResult = RollDie();
                    Console.WriteLine($"You rolled a {rollResult}.");

                    rollCount++;
                    int rollsLeft = 10 - rollCount;
                    RollResult(rollResult, stamina, panicLevel, enemyHealth);
                    BattleResults(rollCount, stamina, panicLevel, enemyHealth);

                    Console.WriteLine($"You have {rollsLeft} rolls left.\n");
                    Console.WriteLine("Current Stats:");
                    DisplayHealthStats(stamina, panicLevel, enemyHealth);

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

        public static void RollResult(int rollResult, int stamina, int panicLevel, int enemyHealth)
        {
            if (rollResult == 1)
            {
                Console.WriteLine("The user gets hit, and their panic level increases by 2.\n");
                panicLevel = panicLevel + 2;
            }
            else if (rollResult == 2)
            {
                Console.WriteLine("The user dodges the attack, but their stamina is reduced by 1.\n");
                stamina--;
            }
            else if (rollResult == 3)
            {
                Console.WriteLine("The user deflects the attack. There is no stat change.\n");
            }
            else if (rollResult == 4)
            {
                Console.WriteLine("The enemy backs away; the user’s stamina increases by 1.\n");
                stamina++;
            }
            else if (rollResult == 5)
            {
                Console.WriteLine("The enemy dodges, but the user strikes a glancing blow. \nThe user’s panic is reduced by 1. The enemy loses 3 hit points.\n");
                panicLevel--;
                enemyHealth = enemyHealth - 3;
            }
            else if (rollResult == 6)
            {
                Console.WriteLine("The enemy takes significant damage. The user’s panic is reduced by 3. \nTheir stamina is increased by 2. The enemy loses 5 hit points.\n");
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
            Console.WriteLine($"ENEMY HEALTH: {enemyHealth}\n");
        }


        //Battle Results
        //After every roll, if the enemy has not died, the user’s panic increases by 1. Their stamina is reduced by 1. 
        //If the enemy has died, another enemy enters the arena.The player’s panic and stamina stay where it is. 
        //If the player has run out of turns, their panic reaches the max level.
        //If the player has died, the dream starts over from the beginning.
        public static void BattleResults(int rollCount, int stamina, int panicLevel, int enemyHealth)
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

