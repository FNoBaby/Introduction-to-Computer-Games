using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void StartGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
        FindObjectOfType<GameSession>().ResetGame();

    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}
