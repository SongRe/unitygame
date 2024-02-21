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
}
