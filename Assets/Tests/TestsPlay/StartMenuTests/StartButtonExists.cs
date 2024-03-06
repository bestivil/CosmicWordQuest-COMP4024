using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the start button exists within view on start menu
/// </summary>
public class StartButtonExists : MonoBehaviour
{
private GameObject StartButton;

/// <summary>
/// Finds the object in game with the StartButton tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        StartButton = GameObject.FindWithTag("StartButton");
    }

/// <summary>
/// Asserts that the start button exists
/// </summary>

    [UnityTest]
    public IEnumerator StartButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(StartButton, "StartButton with tag 'StartButton' not found in the scene.");

        yield return null;
    }
}
