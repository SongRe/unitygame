using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameLogicController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject BasicEnemy;
    public int Difficulty = Constants.Difficulty.EASY;
    public float MinSpawnRadius = 10.0f;
    public float MaxSpawnRadius = 20.0f;

    private CombatEntity _player;
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag(TAGS.Player);
        }
        if (Player != null && _player == null)
        {
            _player = Player.GetComponent<PlayerStatusController>().getPlayer();
        }
        InvokeRepeating("spawnEnemy", 5, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnForceLevelUp()
    {
        print("on force levelup");
        if (_player != null)
        {
            _player.AddModifier(new LevelUpModifier());
        }
    }
    
    private void spawnEnemy()
    {
        Transform playerTransform = Player.transform;
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currentEnemies < EnemyConstants.MaxEnemyMappings.GetValueOrDefault(Difficulty, 10)) {
            float x = Random.Range(playerTransform.transform.position.x + MinSpawnRadius, playerTransform.transform.position.x + MaxSpawnRadius);
            float z = Random.Range(playerTransform.transform.position.z + MinSpawnRadius, playerTransform.transform.position.z + MaxSpawnRadius);

            Vector3 pos = new Vector3(x, playerTransform.position.y, z);
            Instantiate(BasicEnemy, pos, BasicEnemy.transform.rotation);

        }
    }

}
