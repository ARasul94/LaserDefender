using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int score;
    
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        var objects = FindObjectsOfType<GameSession>();
        
                if (objects.Length > 1)
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }
                else
                {
                    DontDestroyOnLoad(gameObject);
                }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
