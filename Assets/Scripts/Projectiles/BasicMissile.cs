using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMissile : MonoBehaviour, ProjectileCombatScript
{
    public float force = 5.0f;
    public float lifetime_inseconds = 5.0f;
    public CombatEntity _instantiator;
    public Ability ability;
    // Start is called before the first frame update
    private Rigidbody _rigidbody;

    CombatEntity ProjectileCombatScript._instantiator
    {
        get
        {
            return _instantiator;
        }

    }
    Ability ProjectileCombatScript.ability
    {
        get
        {
            return ability;
        }
    }

    public void setInstantiator(ref CombatEntity c)
    {
        _instantiator = c;
    }

    public void setAbility(ref Ability a)
    {
        ability = a;
    }

    void Start()
    {
        Destroy(gameObject, lifetime_inseconds);
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidbody.AddForce(_direction * force, ForceMode.Impulse);
        //transform.Translate(_direction * speed * Time.deltaTime);
    }

    public void Fire(Vector3 dir)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(dir * force, ForceMode.Impulse);
    }

}
