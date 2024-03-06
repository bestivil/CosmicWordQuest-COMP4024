using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the bullet button exists within view
/// </summary>

public class BulletExists
{
    private GameObject bullet;

/// <summary>
/// Finds the object in game with the Bullet tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        bullet = GameObject.FindWithTag("Bullet");
    }

/// <summary>
/// Asserts that the bullet exists within view of the camera 
/// </summary>

    [UnityTest]
    public IEnumerator BulletVisible()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Bullet is Outside Camera View");

        yield return null;
    }

    /// <summary>
    /// In the test, make sure that the object targeted is within view of the Main Camera
    /// </summary>
    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(bullet.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}