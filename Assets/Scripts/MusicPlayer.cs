﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        var objects = FindObjectsOfType<MusicPlayer>();
        
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
}
