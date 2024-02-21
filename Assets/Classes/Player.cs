using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CombatEntity
{ 
    // Start is called before the first frame update
    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Stats BaseStats => throw new System.NotImplementedException();

    public Stats ModifiedStats => throw new System.NotImplementedException();

    public void AddModifier(Modifier modifier)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveModifier(Modifier modifier)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return ("test1");
    }

// Update is called once per frame
}
