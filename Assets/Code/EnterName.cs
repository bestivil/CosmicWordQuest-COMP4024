using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    public InputField inputField; // Public if you want to assign it via the Inspector

    void Start()
    {
        // If the InputField is not assigned via the Inspector, find it by tag or another method
        if (inputField == null)
        {
            GameObject usernameDialogObject = GameObject.FindGameObjectWithTag("input");
            if (usernameDialogObject != null)
            {
                inputField = usernameDialogObject.GetComponent<InputField>();
            }
        }

        // Register the onEndEdit event listener
        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(delegate { CheckEnterPress(inputField.text); });
        }
    }

    private void CheckEnterPress(string inputValue)
    {
        // Since onEndEdit is called even when Escape is pressed, check if the Enter or Return key is pressed
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || inputField.isFocused)
        {
            GameManager.Instance.setNames(inputValue); 
            GameManager.Instance.LoadLeaderboard();
        }
    }
}
