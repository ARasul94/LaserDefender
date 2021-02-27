using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BaseMenuButton : MonoBehaviour
{
    public Button ButtonComponent => _buttonComponent;
    public Level LevelObject => _level;
    
    private Button _buttonComponent;
    private Level _level;
    private void Awake()
    {
        _buttonComponent = GetComponent<Button>();
        _level = FindObjectOfType<Level>();
        if (_level == null)
            throw new Exception($"No Level gameobject on scene {SceneManager.GetActiveScene().name}");
    }
}