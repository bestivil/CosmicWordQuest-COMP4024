using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// Class responsible for testing the leaderboard button exists within view
/// </summary>

public class LeaderboardButtonExists : MonoBehaviour
{
private GameObject LeaderboardButton;

/// <summary>
/// Finds the object in game with the LeaderboardButton tag
/// </summary>

    [SetUp]
    public void SetUp()
    {
        LeaderboardButton = GameObject.FindWithTag("LeaderboardButton");
        Assert.IsNotNull(LeaderboardButton, "LeaderboardButton with tag 'LeaderboardButton' not found in the scene.");
    }

/// <summary>
/// Asserts that the leaderboard button exists within view of the camera 
/// </summary>

    [UnityTest]
    public IEnumerator LeaderboardButtonIsWithinGameBounds()
    {
        // Assert
        Assert.IsTrue(IsVisibleByCamera(), "LeaderboardButton is Outside Camera View");

        yield return null;
    }

    /// <summary>
    /// In the test, make sure that the object targeted is within view of the Main Camera
    /// </summary>

    bool IsVisibleByCamera()
    {
        // Get the object's position in the viewport
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(LeaderboardButton.transform.position);

        // Check if the object's position is within the viewport bounds
        return (viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1);
    }
}
