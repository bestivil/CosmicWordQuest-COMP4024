using UnityEngine;

/// <summary>
/// Class responsible for checking if the spaceship is outside of view
/// </summary>
public class SpaceshipOutsideView : MonoBehaviour
{
    private Vector3 startingPosition;
    /// <summary>
    /// initialise starting position
    /// </summary>
    void Start()
    {
        startingPosition = transform.position;

    }
    
    /// <summary>
    /// check if the spaceship is outside of camera view, and if it is put it back in the starting position
    /// </summary>
    void Update()
    {
        // Check if the object is outside the camera's view
        if (!IsVisibleByCamera())
        {
            // Reset the object's position to the starting position
            transform.position = startingPosition;
        }
    }
    /// <summary>
    /// checking if the spaceship is visible
    /// </summary>
    /// <returns>returns a boolean value signifying if the spaceship is visible or not</returns>
    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the object's position is within the viewport bounds
        return viewportPosition.x > -0.1 && viewportPosition.x < 0.9 && viewportPosition.y > 0 && viewportPosition.y < 1;
    }
}
