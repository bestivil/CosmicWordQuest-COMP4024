using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Planet2exists : MonoBehaviour
{
private GameObject planet;

    [SetUp]
    public void SetUp()
    {
        // Assuming your planet has the "Planet2" tag
        planet = GameObject.FindWithTag("Planet2");
        Assert.IsNotNull(planet, "Planet with tag 'Planet2' not found in the scene.");
    }

    [UnityTest]
    public IEnumerator PlanetIsWithinGameBounds()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "Planet is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(planet.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
