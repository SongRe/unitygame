using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsControllerScript : MonoBehaviour, Observer
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI textMesh;

    private CombatEntity _player;
    private Stats _stats;
    private float _health;
    private string _displayString;
    // Start is called before the first frame update
    void Start()
    {
        if (textMesh == null)
        {
            textMesh = FindObjectOfType<TMPro.TextMeshProUGUI>();
        }
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag(TAGS.Player);
        }
        if (Player != null && _player == null) {
            _player = Player.GetComponent<PlayerStatusController>().getPlayer();
            _player.addObserver(this);
            _stats = _player.getStats();
            _health = _player.getHealth();
            updateStats();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textMesh != null)
        {
            textMesh.text = _displayString;
        }
    }

    void Observer.update(string message)
    {
        if (message == PlayerConstants.OBSERVER_MESSAGE.HEALTH_UPDATE || message == PlayerConstants.OBSERVER_MESSAGE.STATS_UPDATE)
        {
            updateStats();
        }
    }


    private void updateStats()
    {
        if (_player != null)
        {
            _stats = _player.getStats();
            _health = _player.getHealth();
        }
        _displayString = "Health: " + _health + " / " + _stats.MaxHealth + "\n\n"
            + "Attack: " + _stats.Attack + "\n"
            + "Defense: " + _stats.Defense + "\n"
            + "Speed: " + _stats.Speed + "\n"
            + "Exp: " + _player.xp_value + "\n";
    }
}
