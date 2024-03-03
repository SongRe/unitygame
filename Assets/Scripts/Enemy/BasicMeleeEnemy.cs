using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeEnemy : MonoBehaviour, EnemyCombatantScript
{
    public GameObject player; // To track towards
    public LayerMask terrainLayermask;
    public float speed = 2.0f;
    public float y_offset = 1.0f; // how high off the ground we should be

    private CombatEntity _meleeEnemy;

    private float _raycastPollingTime = TechnicalConstants.RAYCASTING.POLLING_RATE;
    private float _y_level = 0.0f;
    private Rigidbody _rb;

    public CombatEntity getCombatEntity()
    {
        return _meleeEnemy;
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
        updateYLevel();

    }

    // Update is called once per frame
    void Update()
    {
        _raycastPollingTime -= Time.deltaTime;
        if (_raycastPollingTime <= 0)
        {
            updateYLevel();
            _raycastPollingTime = TechnicalConstants.RAYCASTING.POLLING_RATE;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case TAGS.Player:
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

    private void updateYLevel()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, terrainLayermask))
        {
            _y_level = hit.point.y + y_offset;
        }
    }

    private void moveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 directionToPlayer = playerPos - transform.position;
            directionToPlayer.y = _y_level - transform.position.y;
            directionToPlayer.Normalize();
            transform.Translate(directionToPlayer * speed * Time.deltaTime);
        }
    }


}
