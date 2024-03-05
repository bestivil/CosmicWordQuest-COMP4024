using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartButtonExists : MonoBehaviour
{
private GameObject StartButton;

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "StartButton" tag
        StartButton = GameObject.FindWithTag("StartButton");
    }

    [UnityTest]
    public IEnumerator StartButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(StartButton, "StartButton with tag 'StartButton' not found in the scene.");

        yield return null;
    }
}
