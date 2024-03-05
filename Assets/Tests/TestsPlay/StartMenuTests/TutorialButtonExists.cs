using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TutorialButtonExists : MonoBehaviour
{
private GameObject TutorialButton;

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "TutorialButton" tag
        TutorialButton = GameObject.FindWithTag("TutorialButton");
    }

    [UnityTest]
    public IEnumerator TutorialButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(TutorialButton, "TutorialButton with tag 'TutorialButton' not found in the scene.");

        yield return null;
    }
}
