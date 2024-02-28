using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerConstants
{
    public enum ABILITY_STATE {
        NONE,
        ABILITY_1,
        ABILITY_2,
        ABILITY_3,
        ABILITY_4
    }

    public static class OBSERVER_MESSAGE
    {
        public static string STATS_UPDATE = "stats_update";
    }
}
