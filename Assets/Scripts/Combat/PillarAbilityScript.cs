using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAbilityScript : MonoBehaviour, AbilityScript
{
    public GameObject Indicator;
    public GameObject Pillar;

    private Ability _ability;
    private CombatEntity _instantiator;



    // Start is called before the first frame update
    void Start()
    {
        // TODO: Create PillarAbility class 
    }

    // Update is called once per frame  
    void Update()
    {   
        
    }
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator)
    {
        _instantiator = instantiator;
        //ability.Fire(dir, hitPos);
        SummonPillar(hitPos);
    }


    private void SummonPillar(Vector3 hitPos)
    {
        GameObject pillar = Instantiate(Pillar, hitPos, Quaternion.identity);
        ProjectileCombatScript combatScript = pillar.GetComponent<ProjectileCombatScript>();
        combatScript.setInstantiator(ref _instantiator);
        combatScript.setAbility(ref _ability);
        combatScript.Fire(Vector3.up);
    }

   
    public GameObject GetIndicator()
    {
        return Indicator;
    }
}
