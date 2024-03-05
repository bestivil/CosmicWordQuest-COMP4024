using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipOutsideView : MonoBehaviour
{
    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;

    }
    
    
    void Update()
    {
        // Check if the object is outside the camera's view
        if (!IsVisibleByCamera())
        {
            // Reset the object's position to the starting position
            transform.position = startingPosition;
        }
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > -0.1 && viewportPosition.x < 0.9 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
