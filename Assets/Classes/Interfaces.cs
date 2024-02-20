using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float Health;
}

public interface Modifier
{
    void AdjustStats(ref Stats stats);
}

public interface CombatEntity
{
    float Health { get; set; }
    Stats BaseStats { get; }
    Stats ModifiedStats { get; }

    void AddModifier(Modifier modifier);
    void RemoveModifier(Modifier modifier);
}

public interface AttackLogic
{
    void OnAttack(CombatEntity attacker, CombatEntity defender);
}


public interface Ability 
{
    GameObject GetIndicator();
    void Fire(Vector3 dir, Vector3 pos);

    // Should return the indicator
}

public interface AbilityModifier
{
    void OnActivate();
}


