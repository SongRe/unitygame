using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeEnemyClass : CombatEntity
{
    // 20 attack, 20 def, 5 hp, 2 speed
    private Stats stats = new Stats(20, 20, 5, 2);

    public override void AddModifier(StatModifier modifier)
    {
        throw new System.NotImplementedException();
    }

    public override void addObserver(Observer observer)
    {
        throw new System.NotImplementedException();
    }

    public override void Attacked(ref CombatEntity attacker)
    {
        throw new System.NotImplementedException();
    }

    public override float getHealth()
    {
        throw new System.NotImplementedException();
    }

    public override Stats getStats()
    {
        return stats;
    }

    public override void notifyObservers(string message)
    {
        throw new System.NotImplementedException();
    }

    public override void OnKill(ref CombatEntity killed_entity)
    {
        throw new System.NotImplementedException();
    }

    public override void removeObserver(Observer observer)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        throw new System.NotImplementedException();
    }
}
