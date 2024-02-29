using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class SpaceshipLeftRight : MonoBehaviour
{
    
    public void UpdateSpaceshipPosition()
    {
        
    }

    public Vector3 GetStartPosition()
    {
        
        return Vector3.zero; 
    }
}

public class OutBoundsTest
{
    private Camera mainCamera;
    private GameObject spaceship;
    private SpaceshipLeftRight controller;
    private Vector3 offset = Vector3.up;

    [SetUp]
    public void SetUp()
    {
        mainCamera = new GameObject("MainCamera").AddComponent<Camera>();
        spaceship = new GameObject("Spaceship");
        controller = spaceship.AddComponent<SpaceshipLeftRight>();

        spaceship.transform.position = Vector3.zero;
    }

    [UnityTest]
    public IEnumerator SpaceshipDoesNotGoOutOfBounds()
    {
        // Assuming your SpaceshipLeftRight script has a method to update the spaceship position
        controller.UpdateSpaceshipPosition();

        // Check if spaceship is outside camera view
        bool isOutsideView = false;
        UpdatePositionAboveSpaceship(ref isOutsideView);

        yield return null;

        // Assert your conditions here
        Assert.IsTrue(!isOutsideView); // Replace this condition with your actual check
    }

    void UpdatePositionAboveSpaceship(ref bool isOutsideView)
    {
        if (spaceship != null)
        {
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(spaceship.transform.position);
            isOutsideView = (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1);

            if (isOutsideView)
            {
                Debug.Log("Object is outside camera view: " + spaceship.name);
                spaceship.transform.position = controller.GetStartPosition() + offset;
            }
        }
    }
}
