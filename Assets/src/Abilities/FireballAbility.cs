using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : Ability
{
    public FireballAbility()
    {
        abilityStats.cooldown = 1.0f;
        abilityStats.Speed = 50.0f;
        abilityStats.xScaling = 1.0f;
        abilityStats.yScaling = 1.0f;
        abilityStats.zScaling = 1.0f;
        abilityStats.attackValue = 0.0f;
    }
    public override void AddModifier(OnHitModifier modifier)
    {
        onHitModifiers.Add(modifier);
    }

    public override void AddModifier(AbilitySummonModifier a)
    {
        abilitySummonModifiers.Add(a);
    }

    public override string ToString()
    {
        return "Fireball Ability";
    }
}
