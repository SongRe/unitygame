using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatEntity
{
    private List<Observer> observers;

    public Player()
    {
        observers = new List<Observer>();
        BaseStats = new Stats();
        BaseStats.MaxHealth = 10;
        BaseStats.Attack = 5.0f;
        BaseStats.Speed = 5.0f;
        BaseStats.Defense = 5.0f;
        Health = BaseStats.MaxHealth;
    }

    public override string ToString()
    {
        return ("Player");
    }

    public override Stats getStats()
    {
        return BaseStats;
    }

    public override void AddModifier(StatModifier modifier)
    {
        BaseStats = modifier.applyModifier(BaseStats);
    }

    public override void Attacked(ref CombatEntity attacker)
    {
        Debug.Log(ToString() + " attacked by: " + attacker);
    }

    public override void OnKill(ref CombatEntity killed_entity)
    {
        Debug.Log(ToString() + " killed: " + killed_entity);
    }

    public override void addObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public override void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public override void notifyObservers(string message)
    {
        observers.ForEach(observer => observer.update(message));
    }


    private void levelUp()
    {
        AddModifier(new LevelUpModifier());
        notifyObservers(PlayerConstants.OBSERVER_MESSAGE.STATS_UPDATE); 
    }

    // Update is called once per frame
}
