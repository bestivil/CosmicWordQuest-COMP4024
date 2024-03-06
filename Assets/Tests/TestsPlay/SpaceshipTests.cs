using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing that the spaceship moves as expected when transformed
/// </summary>

public class SpaceshipMovementTests : MonoBehaviour
{
    private GameObject spaceship;
    private float initialXPosition;

/// <summary>
/// Finds the object in game with the Spaceship tag, and records the starting position
/// </summary>

    [SetUp]
    public void SetUp()
    {
        spaceship = GameObject.FindWithTag("Spaceship");

        spaceship.transform.position = Vector3.zero;

    }

/// <summary>
/// Transforms the location of the spaceship and tests to see if movement is moved as expected
/// </summary>

    [UnityTest]
    public IEnumerator SpaceshipMovementWithEnumeratorPasses()
    {        
        spaceship.transform.Translate(Vector3.up * 5000f * Time.deltaTime);

        yield return null;

        Assert.AreNotEqual(Vector3.zero, spaceship.transform.position, "Spaceship did not move as expected.");
        
        yield return null;
    }
}
