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

        public HealthStats(int _stamina, int _panicLevel, int _enemyHealth)
        {
        Stamina = _stamina;
        PanicLevel = _panicLevel;
        EnemyHealth = _enemyHealth;
        }
        
        public HealthStats()
        {
        }

    }
}
