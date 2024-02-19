using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

public class ScoreOnCollision : MonoBehaviour
{
    public int score = 0;
    private Text scoreText; // Changed to private since we'll find it by tag

    void Start()
    {
        // Find the Text component by the "ScoreText" tag
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            
            scoreText = scoreTextObject.GetComponent<Text>();
            UpdateScoreText(); // Initial score update
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
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // Ensure scoreText is not null before attempting to update it
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the text
        }
    }
}
