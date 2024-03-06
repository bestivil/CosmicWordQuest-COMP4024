using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

/// <summary>
/// Class responsible for updating score when a bullet hits a planet
/// </summary>
public class ScoreOnCollision : MonoBehaviour
{
    private Text scoreText; //stores the text for score that is diplayed on canvas

    /// <summary>
    /// sets up planet,score and spaceship object references and texts
    /// </summary>
    void Start()
    {
        GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<Text>();
            UpdateScoreText(); 
        }

        GameObject Planet1Text = GameObject.FindGameObjectWithTag("Planet1Text");
        GameObject Planet2Text = GameObject.FindGameObjectWithTag("Planet2Text");
        GameObject Planet3Text = GameObject.FindGameObjectWithTag("Planet3Text");
        GameObject Planet4Text = GameObject.FindGameObjectWithTag("Planet4Text");
        GameObject Planet5Text = GameObject.FindGameObjectWithTag("Planet5Text");

        List<GameObject> planetList = new()
        {
            Planet1Text,
            Planet2Text,
            Planet3Text,
            Planet4Text,
            Planet5Text
        };

        GameObject SpaceshipWord = GameObject.FindGameObjectWithTag("SpaceshipWord");
        
        if (Planet1Text != null && Planet2Text != null && Planet3Text != null && Planet4Text != null && Planet5Text != null)
        {
            SetupPlanets(planetList);
        }
        //display the english word near spaceship
        SpaceshipWord.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.correctAnswer].English;
    }
    /// <summary>
    /// Checks for which object the collision has occured
    /// </summary>
    /// <param name="collision">The collision parameter used to compare its gameObject parameter with Planet tags</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet5"))
        {
            FinaliseScoring(4);
        }
        else if (collision.gameObject.CompareTag("Planet4"))
        {
            FinaliseScoring(3);
        }
        else if (collision.gameObject.CompareTag("Planet3"))
        {
            FinaliseScoring(2);
        }
        else if (collision.gameObject.CompareTag("Planet2"))
        {
            FinaliseScoring(1);
        }
        else if (collision.gameObject.CompareTag("Planet1"))
        {
            FinaliseScoring(0);
        }

        // On collision, determines if user hits correct answer, 
        // adds a point to the score, and updates the score text
        void FinaliseScoring(int value)
        {
            if (GameManager.Instance.correctAnswer == GameManager.Instance.randomNumbersArray[value])
            {
                GameManager.Instance.liveScore += 1;
                UpdateScoreText();
            }
            
            //get new array of words after collision
            GameManager.Instance.GetRandomArray();

            //reset the texts to match new words
            GameObject Planet1Text = GameObject.FindGameObjectWithTag("Planet1Text");
            GameObject Planet2Text = GameObject.FindGameObjectWithTag("Planet2Text");
            GameObject Planet3Text = GameObject.FindGameObjectWithTag("Planet3Text");
            GameObject Planet4Text = GameObject.FindGameObjectWithTag("Planet4Text");
            GameObject Planet5Text = GameObject.FindGameObjectWithTag("Planet5Text");

            List<GameObject> planetList = new()
            {
                Planet1Text,
                Planet2Text,
                Planet3Text,
                Planet4Text,
                Planet5Text
            };

            GameObject SpaceshipWord = GameObject.FindGameObjectWithTag("SpaceshipWord");
            
            if (Planet1Text != null && Planet2Text != null && Planet3Text != null && Planet4Text != null && Planet5Text != null)
            {
                
                SetupPlanets(planetList);
            }

            SpaceshipWord.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.correctAnswer].English;

        }
    }

    /// <summary>
    /// Checks if the text object is not null, updates the score text
    /// </summary>
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.liveScore; 
        }
    }

    /// <summary>
    /// Sets up the planets with the words in the JSON file in the chosen language
    /// </summary>
    /// <param name="planetList">List of planet GameObject</param>
    void SetupPlanets(List<GameObject> planetList){
        switch(StateController.languageChoice){
            case "French":
                PlanetLangSetup.SetupPlanetsFrench(planetList);
                break;
            case "Spanish":
                PlanetLangSetup.SetupPlanetsSpanish(planetList);
                break;
            case "Italian":
                PlanetLangSetup.SetupPlanetsItalian(planetList);
                break;
        }
    }
}
