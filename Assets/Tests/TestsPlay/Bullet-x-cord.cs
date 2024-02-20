using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletMovementTest : MonoBehaviour
{
    private GameObject bullet;
    private float initialXPosition;

    [SetUp]
    public void SetUp()
    {
        bullet = new GameObject("Bullet");
        var controller = bullet.AddComponent<MoveUpwards>(); // Your custom bullet controller script

        bullet.transform.position = Vector3.zero;

    }

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