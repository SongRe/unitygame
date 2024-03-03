using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    private CombatEntity _player;
    // Start is called before the first frame update

    private void Awake()
    {
        _player = new Player();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ref CombatEntity getPlayer()
    {
        return ref _player;
    }


    public void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case TAGS.Player:
                break;
            case TAGS.Enemy:
                print("Detected collision with enemy object");
                break;
            case TAGS.Projectile:
                ProjectileCombatScript otherAbility = other.GetComponent<ProjectileCombatScript>();
                //BasicMissile basicMissileScript = other.GetComponent<BasicMissile>();
                if (otherAbility != null && otherAbility._instantiator != _player)
                {
                    otherAbility.OnHit(gameObject);
                    CombatEntity attacker = otherAbility._instantiator;
                    _player.Attacked(ref attacker);

                } else
                {
                    print("Error: Collision detected with projectile but no projectile script or no instantiator");
                }
                break;

        }
        
    }
}
