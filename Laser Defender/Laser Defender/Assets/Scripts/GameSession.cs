using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    
    static GameSession instance;
    void Awake()
    {
        //Setting up a Singleton instance of GameSesson
        if (instance != null) //Has my instance been set already?
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject); //Ensures that the GameSession object is not destroyed when a new scene is loaded
        }
        
    }

    public int GetScore()
    {
        return this.score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
