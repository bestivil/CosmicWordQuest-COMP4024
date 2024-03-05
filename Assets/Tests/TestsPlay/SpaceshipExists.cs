using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SpaceshipExists
{
    private GameObject spaceship;

    [SetUp]
    public void SetUp()
    {
        spaceship = GameObject.FindWithTag("Spaceship");
    }

    [UnityTest]
    public IEnumerator SpaceshipVisible()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Spaceship is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(spaceship.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}

