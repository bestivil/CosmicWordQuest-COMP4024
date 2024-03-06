using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the quit button exists within view on start menu
/// </summary>
public class QuitButtonExists : MonoBehaviour
{
private GameObject QuitButton;

/// <summary>
/// Finds the object in game with the QuitButton tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "QuitButton" tag
        QuitButton = GameObject.FindWithTag("QuitButton");
    }

/// <summary>
/// Asserts that the quit button exists
/// </summary>

    [UnityTest]
    public IEnumerator QuitButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(QuitButton, "QuitButton with tag 'QuitButton' not found in the scene.");

        yield return null;
    }
}
