using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbilityScript : MonoBehaviour, AbilityScript
{
    public GameObject Indicator;
    public GameObject Projectile;


    private Ability _ability;
    private CombatEntity _instantiator;

    public void AddModifier(OnHitModifier a)
    {
        _ability.AddModifier(a);
    }

    public void AddModifier(AbilitySummonModifier a)
    {
        _ability.AddModifier(a);
    }
    
    public void Fire(Vector3 dir, Vector3 hitPos, ref CombatEntity instantiator)
    {
        _instantiator = instantiator;
        GameObject fireball = Instantiate(Projectile, hitPos, Quaternion.identity);
        ProjectileCombatScript projectileCombatScript = fireball.GetComponent<ProjectileCombatScript>();
        if (projectileCombatScript != null)
        {
            projectileCombatScript.setInstantiator(ref _instantiator);
            projectileCombatScript.setAbility(ref _ability);
            // TODO: Here we would apply summon modifiers
            projectileCombatScript.Fire(dir);
        }
    }

    public float getAbilityCooldown()
    {
        return _ability.getAbilityStats().cooldown;
    }

    public GameObject GetIndicator()
    {
        return new GameObject();
    }

    public void Initialize()
    {
        _ability = new FireballAbility();
    }

    public void setAbilityStat(AbilityStat e, float value)
    {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
