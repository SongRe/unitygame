using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarAbilityScript : MonoBehaviour, AbilityScript
{
    public GameObject Indicator;
    public GameObject Projectile;

    private Ability _ability;
    private CombatEntity _instantiator;

    public void Initialize()
    {
        _ability = new PillarAbility();
        print("start" + _ability);
    }

    private void Awake()
    {

    }

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
        _instantiator = instantiator;
        //ability.Fire(dir, hitPos);
        SummonPillar(hitPos);
    }
   
    public GameObject GetIndicator()
    {
        return Indicator;
    }

    public void AddModifier(OnHitModifier a)
    {
        _ability.AddModifier(a);
    }

    public void AddModifier(AbilitySummonModifier a)
    {
        _ability.AddModifier(a);
    }

    public void setAbilityStat(AbilityStat e, float value)
    {
        print("ability stat set");
        print(_ability);
        if (_ability != null)
        {
            switch (e)
            {
                case AbilityStat.COOLDOWN:
                    _ability.setCooldown(value);
                    break;
                case AbilityStat.SPEED:
                    _ability.setSpeed(value);
                    break;
                case AbilityStat.X_SCALING:
                    _ability.setXScaling(value);
                    break;
                case AbilityStat.Y_SCALING:
                    _ability.setYScaling(value);
                    break;
                case AbilityStat.Z_SCALING:
                    _ability.setZScaling(value);
                    break;
                default:
                    print("undefined abilitystat");
                    break;
            }
        }
        
    }

    public float getAbilityCooldown()
    {
        return _ability.getAbilityStats().cooldown;
    }

    public override string ToString()
    {
        return "PillarAbilityScript";
    }

    private void SummonPillar(Vector3 hitPos)
    {

        // Apply ability modifiers here
        GameObject pillar = Instantiate(Projectile, hitPos, Quaternion.identity);
        ProjectileCombatScript combatScript = pillar.GetComponent<ProjectileCombatScript>();
        combatScript.setInstantiator(ref _instantiator);
        combatScript.setAbility(ref _ability);
        combatScript.Fire(Vector3.up);
    }
}
