using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Called to load the Leaderboard Scene when pressing Leaderboard icon in main game
/// </summary>
public class LoadLeaderboard : MonoBehaviour
{
    /// <summary>
    /// loads the scene when user presses on the Leaderboard icon
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button was pressed
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("LeaderboardButton"))
            {
                SceneManager.LoadScene("Leaderboard"); // Load the scene
            }
        }
    }
}

