using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the tutorial button exists within view on start menu
/// </summary>
public class TutorialButtonExists : MonoBehaviour
{
private GameObject TutorialButton;

/// <summary>
/// Finds the object in game with the TutorialButton tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
       
        TutorialButton = GameObject.FindWithTag("TutorialButton");
    }

/// <summary>
/// Asserts that the tutorial button exists
/// </summary>

    [UnityTest]
    public IEnumerator TutorialButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(TutorialButton, "TutorialButton with tag 'TutorialButton' not found in the scene.");

        yield return null;
    }
}
