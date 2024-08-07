using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BasicMeleeEnemy : MonoBehaviour, EnemyCombatantScript, Observer
{
    public GameObject player; // To track towards
    public float speed = 2.0f;
    public float y_offset = 1.0f; // how high off the ground we should be

    private CombatEntity self = new BasicMeleeEnemyClass();

    private float _raycastPollingTime = TechnicalConstants.RAYCASTING.POLLING_RATE;
    private Rigidbody _rb;

    public CombatEntity getCombatEntity()
    {
        return self;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag(TAGS.Player);
        }
        if (_rb == null)
        {
            _rb = gameObject.GetComponent<Rigidbody>();
        }
        self.addObserver(this);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case TAGS.Player:
                break;
            case TAGS.Projectile:
                print("Basic Melee Enemy Attacked By Projectile");
                ProjectileCombatScript projectile = other.GetComponent<ProjectileCombatScript>();
                if (projectile != null)
                {
                    Ability ability = projectile.ability;
                    CombatEntity attacker = projectile._instantiator;
                    CombatHelper.battle(ref attacker, ability, ref self);
                }


                break;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case TAGS.Player:
                break;
        }
    }

    private void LateUpdate()
    {
        moveTowardsPlayer();
    }

    private void moveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.y += y_offset;
            Vector3 directionToPlayer = playerPos - transform.position;
            //directionToPlayer.y = playerPos.y;
            directionToPlayer.Normalize();
            transform.Translate(directionToPlayer * self.getStats().Speed * Time.deltaTime);
        }
    }

    void Observer.update(string message)
    {
        if (message == EnemyConstants.OBSERVER_MESSAGE.ENEMY_DEATH)
        {
            Destroy(gameObject);
        }
    }


}
