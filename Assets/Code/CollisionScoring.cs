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

        GameObject Planet1Text = GameObject.FindGameObjectWithTag("Planet1Text");
        GameObject Planet2Text = GameObject.FindGameObjectWithTag("Planet2Text");
        GameObject Planet3Text = GameObject.FindGameObjectWithTag("Planet3Text");
        GameObject Planet4Text = GameObject.FindGameObjectWithTag("Planet4Text");
        GameObject Planet5Text = GameObject.FindGameObjectWithTag("Planet5Text");
        GameObject SpaceshipWord = GameObject.FindGameObjectWithTag("SpaceshipWord");
        if (Planet1Text != null && Planet2Text != null && Planet3Text != null && Planet4Text != null && Planet5Text != null)
        {
            Planet1Text.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].French; // to be changed to StateController.LanguageChoice
            Planet2Text.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].French;
            Planet3Text.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].French;
            Planet4Text.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].French;
            Planet5Text.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].French;
        }
        SpaceshipWord.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.correctAnswer].English;
    
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet5"))
        {
            FinaliseLevel(4);
        }
        else if (collision.gameObject.CompareTag("Planet4"))
        {
            FinaliseLevel(3);
        }
        else if (collision.gameObject.CompareTag("Planet3"))
        {
            FinaliseLevel(2);
        }
        else if (collision.gameObject.CompareTag("Planet2"))
        {
            FinaliseLevel(1);
        }
        else if (collision.gameObject.CompareTag("Planet1"))
        {
            FinaliseLevel(0);
        }

        void FinaliseLevel(int value)
        {
            if (GameManager.Instance.correctAnswer == (GameManager.Instance.randomNumbersArray[value]))
            {
                GameManager.Instance.liveScore += 1;
                UpdateScoreText();
            }
            
            GameManager.Instance.LevelCompleted();
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
