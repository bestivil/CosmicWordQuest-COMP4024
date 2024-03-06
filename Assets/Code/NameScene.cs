using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Class responsible for taking care of 
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    /// <summary>
    /// displays the current score to the scene
    /// </summary>
    void Start()
    {
       // Displays the score of the user during the high score scene.
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("Your_score");
        if (scoreTextObject != null)
        {
           
            if (scoreTextObject.TryGetComponent<Text>(out var scoreText))
            {
                if (GameManager.Instance.scoreUser != "0")
                {
                    scoreText.text = "Your " + GameManager.Instance.scoreUser;
                }
                else
                {
                    scoreText.text = "Your score: 0";
                }
        }
        
    }
}}
