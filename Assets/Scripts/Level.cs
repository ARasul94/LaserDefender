using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
