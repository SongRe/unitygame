using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float Health;
}



public interface CombatEntity
{
    float Health { get; set; }
    Stats BaseStats { get; }
    Stats ModifiedStats { get; }

    //abstract void AddModifier(AbilityModifier modifier);
    //abstract void RemoveModifier(modifier);

    abstract void Attack(ref CombatEntity defender);

    abstract string ToString();
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


