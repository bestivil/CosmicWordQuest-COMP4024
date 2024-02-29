using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OutBoundsTest
{
    private GameObject spaceship;
    private Vector3 startingPosition;


    [SetUp]
    public void SetUp()
    {
        spaceship = GameObject.FindWithTag("Spaceship");

        startingPosition = spaceship.transform.position;

    }

    [UnityTest]
    public IEnumerator SpaceshipDoesNotGoOutOfBounds()
    {
        // Assert
        spaceship.transform.position = startingPosition;

        Assert.IsTrue(IsVisibleByCamera(),"Spaceship is Outside Camera View"); // To test, change IsTrue to IsFalse

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(spaceship.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > -0.1 && viewportPosition.x < 0.9 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
