using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    // Input player number who scored
    public void HandleScore(int player)
    {
        if (score.IncreaseScore(player))
        {
            RestartGame();
        }

        // Reset Ball Position
    }

    void RestartGame()
    {
        score.ResetScore();

        // Reset Ball Position
    }
}