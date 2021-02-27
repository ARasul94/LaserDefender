using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    private Text _score;
    private GameSession _gameSession;
    
    private void Awake()
    {
        _score = GetComponent<Text>();
        _gameSession = FindObjectOfType<GameSession>();
        
        if (_gameSession == null)
            throw new Exception($"No GameSession gameobject on scene {SceneManager.GetActiveScene().name}");
    }

    private void Update()
    {
        _score.text = _gameSession.GetScore().ToString();
    }
}
