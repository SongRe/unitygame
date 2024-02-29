using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float MaxHealth;
    public float Speed;
}


public interface StatModifier
{
    public static float INFINITE_LIFETIME = -1;
    abstract Stats applyModifier(Stats s, ref float health);

    virtual float lifeTime()
    {
        return INFINITE_LIFETIME;
    }
}

public abstract class CombatEntity : Subject
{
    public float xp_value;
    protected float Health;
    protected Stats BaseStats;

    public abstract Stats getStats();

    public abstract float getHealth();
    public abstract void AddModifier(StatModifier modifier);

    /// <summary>
    /// Called by the attacker 
    /// </summary>
    /// <param name="attacker"></param>
    public abstract void Attacked(ref CombatEntity attacker);

    /// <summary>
    ///  Called by the attacked entity when it dies 
    /// </summary>
    /// <param name="killed_entity"></param>
    public abstract void OnKill(ref CombatEntity killed_entity);

    public abstract override string ToString();
    public abstract void addObserver(Observer observer);
    public abstract void removeObserver(Observer observer);
    public abstract void notifyObservers(string message);
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

    /// <summary>
    /// Fire the projectile.
    /// You should apply ability stats here. 
    /// </summary>
    /// <param name="dir">The direction to fire the gameobject projectile.</param>
    void Fire(Vector3 dir);


    /// <summary>
    /// Should be called when a GameObject is hit by an object carrying this script, 
    /// should call ability.getOnHitModifers() and iterate through the modifiers to determine what to do
    /// </summary>
    /// <param name="target"></param>
    void OnHit(GameObject target);

}


public interface Subject
{
    void addObserver(Observer observer);
    void removeObserver(Observer observer);
    void notifyObservers(string message);
}

// Define the observer interface
public interface Observer
{
    void update(string message);
}