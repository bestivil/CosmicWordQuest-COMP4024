using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpaceExists
{
    private GameObject space;

    [SetUp]
    public void SetUp()
    {
        space = GameObject.FindWithTag("Space");
    }

    [UnityTest]
    public IEnumerator SpaceVisible()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Space is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(space.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}