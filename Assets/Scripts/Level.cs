using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private float loadDelay = 2f;
    
    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("Start");
    }
    
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetScore();
    }
    
    public void LoadGameOverScene()
    {
        StartCoroutine(LoadWithDelay(LoadGameOver));
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator LoadWithDelay(Action action)
    {
        yield return new WaitForSeconds(loadDelay);
        action.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
