using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LeaderboardButtonExists : MonoBehaviour
{
private GameObject LeaderboardButton;

    [SetUp]
    public void SetUp()
    {
        // Assuming your button has the "leaderboardButton" tag
        LeaderboardButton = GameObject.FindWithTag("LeaderboardButton");
        Assert.IsNotNull(LeaderboardButton, "LeaderboardButton with tag 'LeaderboardButton' not found in the scene.");
    }

    [UnityTest]
    public IEnumerator LeaderboardButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "LeaderboardButton is Outside Camera View");

        yield return null;
    }

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(LeaderboardButton.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
