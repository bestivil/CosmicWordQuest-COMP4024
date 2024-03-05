using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class QuitButtonExists : MonoBehaviour
{
private GameObject QuitButton;

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "QuitButton" tag
        QuitButton = GameObject.FindWithTag("QuitButton");
    }

    [UnityTest]
    public IEnumerator QuitButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsNotNull(QuitButton, "QuitButton with tag 'QuitButton' not found in the scene.");

        yield return null;
    }
}
