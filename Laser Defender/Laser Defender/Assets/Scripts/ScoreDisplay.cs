using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    TMPro.TextMeshProUGUI scoreText;

    GameSession instance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        instance = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = instance.GetScore().ToString();
    }
}
