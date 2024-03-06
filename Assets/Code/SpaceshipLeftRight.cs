using UnityEngine;

/// <summary>
/// Class responsible for spaceship movements
/// </summary>
public class SpaceshipLeftRight : MonoBehaviour
{
    public float moveSpeed = 5000f; // Speed of movement
    
    /// <summary>
    /// Updates the position of the spacehsip given either a left or right arrow key was pressed
    /// </summary>
    void Update()
    {
        // move spaceship if left arrow pressed; says "up" but moves left since vector is rotated
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.up); 

        }
        // move spaceship if right arrow pressed; says "down" but moves right since vector is rotated
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.down);
        }
       
       
    }
}
