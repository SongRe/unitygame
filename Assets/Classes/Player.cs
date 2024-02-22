using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatEntity
{ 
    // Start is called before the first frame update
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Stats BaseStats => throw new System.NotImplementedException();

    public Stats ModifiedStats => throw new System.NotImplementedException();

    public void AddModifier(OnHitModifier modifier)
    {
        throw new System.NotImplementedException();
    }



    //public void RemoveModifier(AbilityModifier modifier)
    //{
    //    throw new System.NotImplementedException();
    //}

    public override string ToString()
    {
        return ("test1");
    }

    public void Attack(ref CombatEntity defender)
    {
        Debug.Log(ToString() + "attacking: " + ToString());
    }

// Update is called once per frame
}
