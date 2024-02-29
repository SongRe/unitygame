using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelUpModifier : StatModifier
{
    Stats StatModifier.applyModifier(Stats s, ref float Health)
    {
        Health += 1;
        s.MaxHealth += 1;
        s.Defense += 1;
        s.Attack += 1;
        return s;
    }
}