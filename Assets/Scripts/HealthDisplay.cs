using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthDisplay : MonoBehaviour
{
    private Text _health;
    private Player _player;
    
    private void Awake()
    {
        _health = GetComponent<Text>();
        _player = FindObjectOfType<Player>();
        
        if (_player == null)
            throw new Exception($"No GameSession gameobject on scene {SceneManager.GetActiveScene().name}");
    }

    private void Update()
    {
        _health.text = _player.GetHealth().ToString();
    }
}
