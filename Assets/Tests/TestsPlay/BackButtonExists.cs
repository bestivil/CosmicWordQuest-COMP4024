using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BackButtonExists : MonoBehaviour
{
private GameObject BackButton;

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "BackButton" tag
        BackButton = GameObject.FindWithTag("BackButton");
        Assert.IsNotNull(BackButton, "BackButton with tag 'BackButton' not found in the scene.");
    }

    [UnityTest]
    public IEnumerator BackButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "BackButton is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(BackButton.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
