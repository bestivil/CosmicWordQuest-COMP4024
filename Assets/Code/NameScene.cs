using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    void Start()
    {
       
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("Your_score");
        if (scoreTextObject != null)
        {
           
            Text scoreText = scoreTextObject.GetComponent<Text>();
            if (scoreText != null)
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
