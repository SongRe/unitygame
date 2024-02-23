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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s">Speed</param>
    /// <param name="x">xScaling</param>
    /// <param name="y">yScaling</param>
    /// <param name="z">zScaling</param>
    /// <param name="cd">Cooldown</param>
    public AbilityStats(float s, float x, float y, float z, float cd)
    {
        Speed = s;
        xScaling = x;
        yScaling = y;
        zScaling = z;
        cooldown = cd;
    }
}

public enum AbilityStat
{
    SPEED,
    X_SCALING,
    Y_SCALING,
    Z_SCALING,
    COOLDOWN
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

    public abstract void setXScaling(float x);
    public abstract void setYScaling(float y);
    public abstract void setZScaling(float z);
    public abstract void setSpeed(float s);
    public abstract void setCooldown(float cd);


    /// <summary>
    /// Gets a copy of the ability's stats (read only)
    /// </summary>
    /// <returns>The abiility's associated stats</returns>
    public abstract AbilityStats getAbilityStats();


}

/// <summary>
/// Script interface for Abilities that represent skills of the player, and will manipulate CombatScript GameObjects
/// Should store an indicator prefab that represents the ability's preview 
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