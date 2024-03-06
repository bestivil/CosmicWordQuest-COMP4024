using UnityEngine;
using UnityEditor;
/// <summary>
/// Class responsible for Quit button behaviour
/// </summary>
public class Quit : MonoBehaviour
{   
    /// <summary>
    /// Quits the application, if it is in editor mode it stops it playing too
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
            if (EditorApplication.isPlaying){
                EditorApplication.isPlaying = false;
            }
        #else
            Application.Quit();
        #endif
    }
}