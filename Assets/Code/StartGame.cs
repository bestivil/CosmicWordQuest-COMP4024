using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class responsible for getting the choice from toggle group of language choices, and starting the game
/// </summary>
public class StartGame : MonoBehaviour
{
    ToggleGroup toggleGroup;
    
    /// <summary>
    /// get the reference to the ToggleGroup
    /// </summary>
    void Start(){
        toggleGroup = GetComponent<ToggleGroup>();
    }
    /// <summary>
    /// gets the language user chose and starts the CosmicWordQuest scene to play the game
    /// </summary>
    public void OnClick(){
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();

        StateController.languageChoice = toggle.name; //set the language choice and retrieve in other scenes

        SceneManager.LoadScene("CosmicWordQuest"); // Load the game scene
    }
}
