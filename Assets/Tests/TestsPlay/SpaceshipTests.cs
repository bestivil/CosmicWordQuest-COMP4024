using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpaceshipMovementTests : MonoBehaviour
{
    private GameObject spaceship;
    private float initialXPosition;

    [SetUp]
    public void SetUp()
    {
        spaceship = new GameObject("Spaceship");
        var controller = spaceship.AddComponent<SpaceshipLeftRight>(); // Your custom spaceship controller script

        spaceship.transform.position = Vector3.zero;

    }

    [TearDown]
    public void Teardown()
    {
        if (spaceship != null)
        {
            GameObject.Destroy(spaceship);
        }
    }

    [UnityTest]
    public IEnumerator SpaceshipMovementWithEnumeratorPasses()
    {
        
        var spaceshipController = spaceship.GetComponent<SpaceshipLeftRight>();
        spaceship.transform.Translate(Vector3.up * 5000f * Time.deltaTime);

        yield return null;

        Assert.AreNotEqual(Vector3.zero, spaceship.transform.position, "Spaceship did not move as expected.");
        
        yield return null;
    }
}
