using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLeftRight : MonoBehaviour
{
    public float moveSpeed = 5000f; // Speed of movement

    // Update is called once per frame
    void Update()
    {
        // move spaceship if left arrow pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 

        }
        // move spaceship if right arrow pressed
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
       
    }
}
