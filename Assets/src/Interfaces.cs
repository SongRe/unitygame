using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float MaxHealth;
    public float Speed;

    public Stats(float A, float D, float H, float S)
    {
        Attack = A; Defense = D; MaxHealth = H; Speed = S;
    }
}


public interface StatModifier
{
    public static float INFINITE_LIFETIME = -1;

    /// <summary>
    /// This method should return a new, modified stats object
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    abstract Stats applyModifier(Stats s);

    virtual float lifeTime()
    {
        return INFINITE_LIFETIME;
    }
}
public interface EnemyCombatantScript
{
    CombatEntity getCombatEntity();
}



/// <summary>
/// The script interface for GameObjects that are instantiated and manipulated 
/// Represent actual game objects that are fired (ex: missiles)
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