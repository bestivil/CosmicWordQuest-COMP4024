using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class ScoreOnCollision : MonoBehaviour
{
    private Text scoreText; 

    void Start()
    {
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            
            scoreText = scoreTextObject.GetComponent<Text>();
            UpdateScoreText(); 
        }
        else
        {
            Debug.LogError("No game object with tag 'ScoreText' found.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet4"))
        {
            GameManager.Instance.liveScore++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.liveScore; 
        }
    }
}
