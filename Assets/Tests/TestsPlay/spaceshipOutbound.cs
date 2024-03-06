using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing that the spaceship is not out of bounds
/// </summary>

public class OutBoundsTest
{
    private GameObject spaceship;
    private Vector3 startingPosition;

/// <summary>
/// Finds the object in game with the Spaceship tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        spaceship = GameObject.FindWithTag("Spaceship");

        startingPosition = spaceship.transform.position;

    }

/// <summary>
/// Asserts that the spaceship exists within view of the camera 
/// </summary>

    [UnityTest]
    public IEnumerator SpaceshipDoesNotGoOutOfBounds()
    {
        // Assert
        spaceship.transform.position = startingPosition;

        Assert.IsTrue(IsVisibleByCamera(),"Spaceship is Outside Camera View"); // To test, change IsTrue to IsFalse

        yield return null;
    }

    /// <summary>
    /// In the test, make sure that the object targeted is within view of the Main Camera
    /// </summary>

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(spaceship.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > -0.1 && viewportPosition.x < 0.9 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
