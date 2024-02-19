using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Score score;
    Ball ball;

    void Start()
    {
        score = FindObjectOfType<Score>();
        ball = FindObjectOfType<Ball>();
    }

    // Input player number who scored
    public void HandleScore(int player)
    {
        if (score.IncreaseScore(player))
        {
            RestartGame();
        }

        ball.ResetBallPosition(player);
    }

    void RestartGame()
    {
        score.ResetScore();

        ball.ResetBallPosition(1);
    }
}