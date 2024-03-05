using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletExists
{
    private GameObject bullet;

    [SetUp]
    public void SetUp()
    {
        bullet = GameObject.FindWithTag("Bullet");
    }

    [UnityTest]
    public IEnumerator BulletVisible()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Bullet is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(bullet.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}