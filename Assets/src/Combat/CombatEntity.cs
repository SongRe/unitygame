using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent entities that have combat capabilities (player, enemy)
/// </summary>
public abstract class CombatEntity : Subject
{
    public float xp_value;
    protected float Health;
    protected Stats BaseStats;
    protected List<Observer> observers = new List<Observer>();

    public virtual Stats getStats()
    {
        return BaseStats;
    }

    public virtual float getHealth()
    {
        return Health;
    }
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
    public virtual void addObserver(Observer observer)
    {
        observers.Add(observer);
    }
    public virtual void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }
    public virtual void notifyObservers(string message)
    {
        observers.ForEach(observer => observer.update(message));
    }
}