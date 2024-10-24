using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerScore : MonoBehaviour
{
    public static playerScore instance;

    public TMP_Text scoreText;
    public int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    
    public void IncreaseScore(int v)
    {
        currentScore += v;
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        if (currentScore >= 10)
        {
            pauseMenu.GameIsWon = true;
        }
    }
}
