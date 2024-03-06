using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the space canvas exists within view
/// </summary>

public class SpaceExists
{
    private GameObject space;

/// <summary>
/// Finds the canvas in game with the Space tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        space = GameObject.FindWithTag("Space");
    }

/// <summary>
/// Asserts that the space canvas exists within view of the camera 
/// </summary>

    [UnityTest]
    public IEnumerator SpaceVisible()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Space is Outside Camera View");

        yield return null;
    }

    /// <summary>
    /// In the test, make sure that the object targeted is within view of the Main Camera
    /// </summary>

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(space.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}