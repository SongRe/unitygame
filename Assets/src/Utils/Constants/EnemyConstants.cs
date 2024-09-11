using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyConstants
{
    public static class OBSERVER_MESSAGE
    {
        public static readonly string ENEMY_DEATH = "death";
    }

    public static readonly Dictionary<int, int> MaxEnemyMappings = new Dictionary<int, int>
    {
        { Constants.Difficulty.EASY, 10 },
        { Constants.Difficulty.MED, 20 },
        { Constants.Difficulty.HARD, 30 }
    };
}
