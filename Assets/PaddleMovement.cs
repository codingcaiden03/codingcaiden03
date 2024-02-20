using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public GameObject Center;
    public float movespeed = 2;
    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (Center.transform.position.x < this.transform.position.x)//to the right of the center aka arrow keys
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
        else if(Center.transform.position.x > this.transform.position.x)//to the left of the center aka wasd
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
