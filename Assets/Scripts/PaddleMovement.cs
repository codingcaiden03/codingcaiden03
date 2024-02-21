using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] Transform Center;
    [SerializeField] float movespeed = 2;

    bool isRightPaddle;

    void Start()
    {
        // True: to the right of the center aka arrow keys, False: to the left of the center aka wasd
        isRightPaddle = (Center.position.x < this.transform.position.x);
    }

    void FixedUpdate()
    {
        if (isRightPaddle)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position = new Vector3(transform.position.x , transform.position.y + movespeed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y - movespeed);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y + movespeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position = new Vector3(transform.position.x, transform.position.y - movespeed);
            }
        }
    }
}