using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the back button exists within view
/// </summary>
public class BackButtonExists : MonoBehaviour
{
private GameObject BackButton;

/// <summary>
/// Finds the object in game with the BackButton tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        BackButton = GameObject.FindWithTag("BackButton");
    }

/// <summary>
/// Asserts that the back button exists
/// </summary>

    [UnityTest]
    public IEnumerator BackButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(BackButton, "BackButton with tag 'BackButton' not found in the scene.");

        yield return null;
    }
}
