using System;

namespace BattleArena
{
    class Program
    {
        int stamina = 10;
        int panicLevel = 10;
        int enemyHealth = 10;
        int diceRoll;
        int rollResult;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Battle Arean!");
            Console.WriteLine("Press the SPACEBAR to roll the die.");
            
        }

        public int RollDie()
        {
            //The user has 10 rolls of the die to defeat the enemy. 
            int rollCount = 0;
            while (rollCount <= 10)
            {
                diceRoll = new Random().Next(1, 7);
                return diceRoll;
                rollCount++;
            }
        }

        public void RollResult()
        {
            if (diceRoll == 1)
            {
                //1 – The user gets hit, and their panic level increases by 2
                panicLevel = panicLevel + 2;
                DisplayHealthStats();
            }
            else if (diceRoll == 2)
            {
                //2 – The user dodges the attack, but their stamina is reduced by 1
                stamina--;
                DisplayHealthStats();

            }
            else if (diceRoll == 3)
            {
                //3 – The user deflects the attack. There is no stat change
                DisplayHealthStats();

            }
            else if (diceRoll == 4)
            {
                //4 – The enemy backs away; the user’s stamina increases by 1
                stamina++;
                DisplayHealthStats();

            }
            else if (diceRoll == 5)
            {
                //5 – The enemy dodges, but the user strikes a glancing blow. The user’s panic is reduced by 1. The enemy loses 3 hit points. 
                panicLevel--;
                enemyHealth = enemyHealth - 3;
                DisplayHealthStats();


            }
            else if (diceRoll == 6)
            {
                //6 – The enemy takes significant damage. The user’s panic is reduced by 3. Their stamina is increased by 2. The enemy loses 5 hit points. 
                panicLevel = panicLevel - 3;
                stamina = stamina + 2;
                enemyHealth = enemyHealth - 5;
                DisplayHealthStats();
            }
        }

        public void DisplayHealthStats()
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
    }
}
