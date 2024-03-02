using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button was pressed
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("BackButton")) 
            {
                SceneManager.LoadScene("StartScreen"); // Load the scene
            }
        }
    }
}

