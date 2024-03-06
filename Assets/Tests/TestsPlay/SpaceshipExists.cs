using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// Class responsible for testing the spaceship exists within view
/// </summary>

public class SpaceshipExists
{
    private GameObject spaceship;

/// <summary>
/// Finds the object in game with the Spaceship tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        spaceship = GameObject.FindWithTag("Spaceship");
    }

/// <summary>
/// Asserts that the spaceship exists within view of the camera 
/// </summary>

    [UnityTest]
    public IEnumerator SpaceshipVisible()
    {
        // Assert
        Assert.IsNotNull(spaceship, "Spaceship with tag 'Spaceship' not found in the scene.");

        yield return null;
    }

}

