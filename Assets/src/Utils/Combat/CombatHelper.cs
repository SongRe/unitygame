using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CombatHelper
{
    public static void battle(ref CombatEntity attacker, ref CombatEntity defender)
    {
        // For now we will do simple calculation
        defender.Attacked(ref attacker);
    }

    public static void battle(ref CombatEntity attacker, Ability ability, ref CombatEntity defender)
    {
        defender.Attacked(ability, ref attacker);
    }
}
