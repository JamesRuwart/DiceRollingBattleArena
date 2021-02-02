using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena
{
    class HealthStats
    {

        public int Stamina { get; set; } = 10;
        public int PanicLevel { get; set; } = 10;
        public int EnemyHealth { get; set; } = 10;

        public HealthStats(int stamina, int panicLevel, int enemyHealth)
        {
        Stamina = stamina;
        PanicLevel = panicLevel;
        EnemyHealth = enemyHealth;
        }
        
        public HealthStats()
        {
        }

    }
}
