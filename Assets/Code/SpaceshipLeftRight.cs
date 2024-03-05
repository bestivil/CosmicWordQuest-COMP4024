using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLeftRight : MonoBehaviour
{
    public float moveSpeed = 5000f; // Speed of movement

    void Update()
    {
        // move spaceship if left arrow pressed; says "up" but moves left since vector is rotated
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); 

        }
        // move spaceship if right arrow pressed; says "down" but moves right since vector is rotated
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
       
       
    }
}
