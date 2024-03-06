using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Class for letting user input their user name
/// </summary>
public class EnterName : MonoBehaviour
{
    public InputField inputField; 
    /// <summary>
    /// sets up InputField member of this class
    /// </summary>
    void Start()
    {
        if (inputField == null)
        {
            GameObject usernameDialogObject = GameObject.FindGameObjectWithTag("input");
            if (usernameDialogObject != null)
            {
                inputField = usernameDialogObject.GetComponent<InputField>();
            }
        }

        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(delegate { CheckEnterPress(inputField.text); });
        }
    }
    /// <summary>
    /// Checks for user pressing Enter key and then stores the name and loads Leaderboad scene
    /// </summary>
    /// <param name="inputValue">user input text</param>
    private void CheckEnterPress(string inputValue)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || inputField.isFocused)
        {
            GameManager.Instance.SetNames(inputValue); 
            GameManager.Instance.LoadLeaderboard();
        }
    }
}
