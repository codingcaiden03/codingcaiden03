using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    [SerializeField] Transform paddleOne; // Left
    [SerializeField] Transform paddleTwo; // Right
    [SerializeField] int ceilingY = 150; // Top
    [SerializeField] int floorY = 1; // Bottom

    [SerializeField] int leftWall = 1; // left edge of screen
    [SerializeField] int rightWall = 200; // right edge of screen

    int ballSize; // from bottom right corner
    int paddleXSize; // from bottom right corner
    int paddleYSize; // from bottom right corner

    Ball ball;
    GameManager gameManager;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();

        ballSize = (int)ball.transform.localScale.y;
        paddleXSize = (int)paddleOne.localScale.x;
        paddleYSize = (int)paddleOne.localScale.y;
    }

    void FixedUpdate()
    {
        ball.Move();
        HandleCollisions();
    }

    void HandleCollisions()
    {
        Vector2 ballPosition = ball.transform.position;
        Vector2 paddleOnePos = paddleOne.position;
        Vector2 paddleTwoPos = paddleTwo.position;

        // Collision with Ceiling or Floor
        if ((ballPosition.y + ballSize) >= ceilingY || ballPosition.y <= floorY)
        {
            ball.FlipYVelocity();
        }

        // Collision with paddleOne on x-axis
        if (ballPosition.x <= (paddleOnePos.x + paddleXSize) && (ballPosition.x + ballSize) >= paddleOnePos.x)
        {
            // Collision with paddleOne on y-axis
            if (ballPosition.y <= (paddleOnePos.y + paddleYSize) && (ballPosition.y + ballSize) >= paddleOnePos.y)
            {
                ball.FlipXVelocity();
                ball.SetYVelocity((paddleYSize / 2) + ((int)paddleOnePos.y));
            }
        }

        // Collision with paddleTwo on x-axis
        else if (ballPosition.x <= (paddleTwoPos.x + paddleXSize) && (ballPosition.x + ballSize) >= paddleTwoPos.x)
        {
            // Collision with paddleOne on y-axis
            if (ballPosition.y <= (paddleTwoPos.y + paddleYSize) && (ballPosition.y + ballSize) >= paddleTwoPos.y)
            {
                ball.FlipXVelocity();
                ball.SetYVelocity((paddleYSize / 2) + ((int)paddleTwoPos.y));
            }
        }

        // Player 2 scores
        if (ballPosition.x <= leftWall)
        {
            gameManager.HandleScore(2);
        }
        else if ((ballPosition.x + ballSize) >= rightWall)
        {
            gameManager.HandleScore(1);
        }
    }
}