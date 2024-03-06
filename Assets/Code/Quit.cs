using UnityEngine;

/// <summary>
/// Class responsible for Quit button behaviour
/// </summary>
public class Quit : MonoBehaviour
{   
    /// <summary>
    /// Quits the application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}