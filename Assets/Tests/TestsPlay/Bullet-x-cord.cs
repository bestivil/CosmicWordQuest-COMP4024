using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing that the bullet maintains the same x-coordinate while moving 
/// </summary>
public class BulletMovementTest : MonoBehaviour
{
    private GameObject bullet;
    private float initialXPosition;

/// <summary>
/// Finds the object in game with the Bullet tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        bullet = new GameObject("Bullet");
        var controller = bullet.AddComponent<MoveUpwards>();

        bullet.transform.position = Vector3.zero;

    }

/// <summary>
/// Moves the bullet upwards and asserts whether the bullet has maintained the same x-coordinate
/// </summary>

[UnityTest]
public IEnumerator BulletMaintainsSameXCoordinate()
{
    // Arrange
    var bulletController = bullet.GetComponent<MoveUpwards>();
    initialXPosition = bullet.transform.position.x;

    yield return null;

    // Assert
    Assert.AreEqual(initialXPosition, bullet.transform.position.x, "X-coordinate changed unexpectedly."); //to test, change x to y

    yield return null;
 }
}