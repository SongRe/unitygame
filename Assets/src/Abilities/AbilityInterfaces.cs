using System.Collections;
using System.Collections.Generic;
using UnityEngine;







/// <summary>
/// Stats that modify the projectile's speed and size. The damage the projectile does should be based off the instantiator's health.
/// </summary>
public struct AbilityStats
{
    public float Speed;
    public float xScaling;
    public float yScaling;
    public float zScaling;
    public float cooldown;
    public float attackValue;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="s">Speed</param>
    /// <param name="x">xScaling</param>
    /// <param name="y">yScaling</param>
    /// <param name="z">zScaling</param>
    /// <param name="cd">Cooldown</param>
    /// <param name="av">Attack Value</param>
    public AbilityStats(float s, float x, float y, float z, float cd, float av)
    {
        Speed = s;
        xScaling = x;
        yScaling = y;
        zScaling = z;
        cooldown = cd;
        attackValue = av;
    }
}

public enum AbilityStat
{
    SPEED,
    X_SCALING,
    Y_SCALING,
    Z_SCALING,
    COOLDOWN,
    ATTACK_VALUE,
}

/// <summary>
/// Class for abilities that represent the player's skills. ProjectileCombatScripts should use these values to modify the projectile that is instantiated. 
/// Should contain an AbilityStats private struct. 
/// </summary>
public abstract class Ability
{
    protected AbilityStats abilityStats;
    protected HashSet<OnHitModifier> onHitModifiers;
    protected HashSet<AbilitySummonModifier> abilitySummonModifiers;

    public abstract void AddModifier(OnHitModifier modifier);
    public abstract void AddModifier(AbilitySummonModifier a);

    public virtual void setXScaling(float x)
    {
        abilityStats.xScaling = x;
    }
    public virtual void setYScaling(float y)
    {
        abilityStats.yScaling = y;
    }
    public virtual void setZScaling(float z)
    {
        abilityStats.zScaling = z;
    }
    public virtual void setSpeed(float s)
    {
        abilityStats.Speed = s;
    }
    public virtual void setCooldown(float cd)
    {
        abilityStats.cooldown = cd;
    }

    public virtual void setAttackValue(float av)
    {
        abilityStats.attackValue = av;
    }


    /// <summary>
    /// Gets a copy of the ability's stats (read only)
    /// </summary>
    /// <returns>The abiility's associated stats</returns>
    public virtual AbilityStats getAbilityStats()
    {
        return abilityStats;
    }


}

/// <summary>
/// Script interface for Abilities that represent skills of the player, and will manipulate ProjectileCombatScript GameObjects
/// Can store an indicator prefab that represents the ability's preview 
/// </summary>
public interface AbilityScript
{
    /// <summary>
    /// Call this whenever you GetComponent<AbilityScript>(). 
    /// </summary>
    public void Initialize();


    /// <summary>
    /// This method should summon the private Projectile GameObject in this script. 
    /// </summary>
    /// <param name="dir">The direction to fire the object</param>
    /// <param name="hitPos">The position to instantiate it at</param>
    /// <param name="instantiator">Who summoned the object</param>
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator);
    public GameObject GetIndicator();

    public void AddModifier(OnHitModifier a);
    public void AddModifier(AbilitySummonModifier a);

    public void setAbilityStat(AbilityStat e, float value);

    public float getAbilityCooldown();


}