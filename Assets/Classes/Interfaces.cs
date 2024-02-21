using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float Health;
}

/// <summary>
/// Stats that modify the projectile's speed and size. The damage the projectile does should be based off the instantiator's health.
/// </summary>
public struct AbilityStats
{
    public float Speed;
    public float xScaling;
    public float yScaling;
    public float zScaling;
    public AbilityStats(float s, float x, float y, float z)
    {
        Speed = s;
        xScaling = x;
        yScaling = y;
        zScaling = z;
    }
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

    abstract void AddModifier(Modifier modifier);
    abstract void RemoveModifier(Modifier modifier);

    abstract void Attack(ref CombatEntity defender);

    abstract string ToString();
}

/// <summary>
/// Interface for abilities that represent the player's skills. ProjectileCombatScripts should use these values to modify the projectile that is instantiated. 
/// Should contain an AbilityStats private struct. 
/// </summary>
public interface Ability
{
    AbilityStats abilityStats { get; }

    //TODO: List of ability modifiers 

}


/// <summary>
/// Script interface for Abilities that represent skills of the player, and will manipulate CombatScript GameObjects
/// Should store an indicator prefab that represents the ability's preview 
/// </summary>
public interface AbilityScript
{
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator);
    public GameObject GetIndicator();
}

/// <summary>
/// The script interface for GameObjects that are instantiated and manipulated 
/// </summary>
public interface ProjectileCombatScript
{
    Ability ability { get; }
    CombatEntity _instantiator { get; }

    void setInstantiator(ref CombatEntity c);
    void setAbility(ref Ability a);

    void Fire(Vector3 dir);

}

public interface AbilityModifier
{
    void OnActivate();
}


