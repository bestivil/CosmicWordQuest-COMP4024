using UnityEngine;

/// <summary>
/// Class responsible for re-stating a bullet after it is fired
/// </summary>
public class OutBounds : MonoBehaviour
{
    private Vector2 startingPosition;
    private Camera mainCamera;
    private Transform spaceshipTransform;
    private Vector3 offset = new(1.55f, -0.3f, 0f); 

    /// <summary>
    /// store the starting position and spaceshipTransform
    /// </summary>
    void Start()
    {
        startingPosition = transform.position;
        mainCamera = Camera.main;

        GameObject spaceshipObject = GameObject.FindGameObjectWithTag("Spaceship");
        if (spaceshipObject != null)
        {
            spaceshipTransform = spaceshipObject.transform;
        }
    }

    /// <summary>
    /// updates the bullet position
    /// </summary>
    void Update()
    {

        if (spaceshipTransform != null)
        {
            UpdatePositionAboveSpaceship();
        }
    }

    /// <summary>
    /// checks if the bullet is outside view, and brings it back if it is
    /// </summary>
    void UpdatePositionAboveSpaceship()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        bool isOutsideView = viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1;

        if (isOutsideView)
            {
                transform.position = spaceshipTransform.position + offset;
            }
    }
}