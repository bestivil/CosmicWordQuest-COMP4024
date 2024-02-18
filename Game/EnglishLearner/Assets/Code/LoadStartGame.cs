using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button was pressed
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("StartButton")) // Check if 'WhiteButton' was clicked
            {
                SceneManager.LoadScene("CosmicWordQuest"); // Load the scene
            }
        }
    }
}
