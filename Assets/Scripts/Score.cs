using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int player1Score = 0;
    int player2Score = 0;

    // List of the display numbers 0 - 9
    [SerializeField] List<GameObject> player1Display;
    [SerializeField] List<GameObject> player2Display;

    // Input player number of who scored, returns TRUE if game is over
    public bool IncreaseScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }

        UpdateScoreDisplay();

        if (player1Score >= 10 || player2Score >= 10)
        {
            return true;
        }

        return false;
    }

    // Reset score when game ends
    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;

        UpdateScoreDisplay();
    }

    // Updates score counter in-game
    void UpdateScoreDisplay()
    {
        // Deactivate all score values for P1 and P2
        for (int i = 0; i < player1Display.Count; i++)
        {
            player1Display[i].SetActive(false);
        }

        for (int i = 0; i < player2Display.Count; i++)
        {
            player2Display[i].SetActive(false);
        }

        // Activate only current score value for P1 and P2
        player1Display[player1Score].SetActive(true);
        player1Display[player2Score].SetActive(true);
    }
}