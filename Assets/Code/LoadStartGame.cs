using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadStartGame : MonoBehaviour
{
    ToggleGroup toggleGroup;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button was pressed
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("StartButton")) // Check if 'WhiteButton' was clicked
            {

                // will need code here to get the current language choice

                toggleGroup = GetComponent<ToggleGroup>();


                SceneManager.LoadScene("CosmicWordQuest"); // Load the scene
            }
        }
    }
    

    public void onClick(){
        SceneManager.LoadScene("CosmicWordQuest"); // Load the game scene
    }
}
