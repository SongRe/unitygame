using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAbility : AbilityDecorator
{
    public PillarAbility(Ability ability) : base(ability) { }
    protected GameObject _pillar;
    protected GameObject _indicator;

    public PillarAbility(Ability ability, GameObject pillar, GameObject indicator) : base(ability)
    {
        _pillar = pillar;
        _indicator = indicator;
    }

    public override void Fire(Vector3 dir, Vector3 pos)
    {
    }

    public override GameObject GetIndicator()
    {
        return base.GetIndicator();
    }
}
