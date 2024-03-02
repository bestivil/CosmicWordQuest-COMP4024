using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnterName : MonoBehaviour
{
    public InputField inputField; 

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

    private void CheckEnterPress(string inputValue)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || inputField.isFocused)
        {
            GameManager.Instance.setNames(inputValue); 
            GameManager.Instance.LoadLeaderboard();
        }
    }
}
