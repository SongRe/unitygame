using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAbilityScript : MonoBehaviour, AbilityScript
{
    public GameObject Indicator;
    public GameObject Pillar;

    private Ability ability;
    private CombatEntity _instantiator;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame  
    void Update()
    {   
        
    }
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator)
    {
        print("pillar ability script fire");
        print(instantiator);
        _instantiator = instantiator;
        //ability.Fire(dir, hitPos);
        SummonPillar(hitPos);
    }


    private void SummonPillar(Vector3 hitPos)
    {
        GameObject pillar = Instantiate(Pillar, hitPos, Quaternion.identity);
        pillar.GetComponent<BasicMissile>().Fire(Vector3.up);
        pillar.GetComponent<BasicMissile>().setInstantiator(ref _instantiator);
    }

   
    public GameObject GetIndicator()
    {
        return Indicator;
    }
}