using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatEntity
{
    private List<Observer> observers;
    private int _level = 1;
    private float xp_threshold = 50;
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

    public override float getHealth()
    {
        return Health;
    }

    public override void AddModifier(StatModifier modifier)
    {
        BaseStats = modifier.applyModifier(BaseStats, ref Health);
        notifyObservers(PlayerConstants.OBSERVER_MESSAGE.STATS_UPDATE);
    }

    public override void Attacked(ref CombatEntity attacker)
    {
        Debug.Log(ToString() + " attacked by: " + attacker);
    }

    public override void OnKill(ref CombatEntity killed_entity)
    {
        Debug.Log(ToString() + " killed: " + killed_entity);
        xp_value += killed_entity.xp_value;
        if (xp_value >= xp_threshold)
        {
            int levelsToGain = (int) (xp_value / xp_threshold);
            for (int i = 0; i < levelsToGain; ++i)
            {
                levelUp();
            }
            xp_value = xp_value % xp_threshold;
            
        }

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
        _level += 1;
        AddModifier(new LevelUpModifier());
        notifyObservers(PlayerConstants.OBSERVER_MESSAGE.STATS_UPDATE); 
    }

    // Update is called once per frame
}
