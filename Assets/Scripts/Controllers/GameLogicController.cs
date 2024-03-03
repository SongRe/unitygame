using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;

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
}
