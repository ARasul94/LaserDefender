
using System;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private void Awake()
    {
        var objects = FindObjectsOfType<Singleton>();

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
