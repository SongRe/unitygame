using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public float Attack;
    public float Defense;
    public float Health;
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

    abstract void Attack(CombatEntity defender);

    abstract string ToString();
}

public interface Ability 
{
    GameObject GetIndicator();
    void Fire(Vector3 dir, Vector3 pos);

    // Should return the indicator
}

public interface AbilityScript
{
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator);
    public GameObject GetIndicator();
}

public interface CombatScript
{
    CombatEntity _instantiator { get; }

    void setInstantiator(ref CombatEntity c);


}

public interface AbilityModifier
{
    void OnActivate();
}


