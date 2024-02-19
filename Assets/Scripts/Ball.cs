using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int xStartingOffset = 50;
    [SerializeField] float maxYVelocity = 2f;

    int xVelocity = 1;
    float yVelocity = -1;

    // Called by PhysicsManager each FixedUpdate
    public void Move()
    {
        transform.position = new Vector2(xVelocity + transform.position.x, yVelocity + transform.position.y);
    }

    public void FlipXVelocity()
    {
        xVelocity = -xVelocity;
    }

    public void SetXVelocity(int sign)
    {
        xVelocity = (int)Mathf.Sign(sign);
    }

    public void FlipYVelocity()
    {
        yVelocity = -yVelocity;
    }

    // Input Paddle's y-coord center point
    public void SetYVelocity(int paddleCenter)
    {
        int ballCenter = 2 + (int)transform.position.y;

        yVelocity = (ballCenter - paddleCenter) / 3;

        if (yVelocity > maxYVelocity)
        {
            yVelocity = maxYVelocity;
        }
        else if (yVelocity < maxYVelocity)
        {
            yVelocity = -maxYVelocity;
        }
    }

    // Input player who scored to decide starting direction
    public void ResetBallPosition(int player)
    {
        // Set Ball's position on the side of who scored
        if (1 == player)
        {
            transform.position = new Vector2(100 - xStartingOffset, 75);
            // Set Ball's x velocity in the positive direction
            SetXVelocity(1);
        }
        else
        {
            transform.position = new Vector2(100 + xStartingOffset, 75);
            // Set Ball's x velocity in the negative direction
            SetXVelocity(-1);
        }
    }
}