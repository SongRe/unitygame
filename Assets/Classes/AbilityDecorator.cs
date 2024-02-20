using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityDecorator : Ability
{
    protected Ability IAbility;

    public AbilityDecorator(Ability ab)
    {
        IAbility = ab;
    }

    public virtual void Fire(Vector3 dir, Vector3 pos)
    {
        IAbility.Fire(dir, pos);
    }

    public virtual GameObject GetIndicator()
    {
        return IAbility.GetIndicator();
    }
}
