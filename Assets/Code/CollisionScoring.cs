using System;
using System.Collections.Generic;
using System.Reflection;
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

        GameObject Planet1Text = GameObject.FindGameObjectWithTag("Planet1Text");
        GameObject Planet2Text = GameObject.FindGameObjectWithTag("Planet2Text");
        GameObject Planet3Text = GameObject.FindGameObjectWithTag("Planet3Text");
        GameObject Planet4Text = GameObject.FindGameObjectWithTag("Planet4Text");
        GameObject Planet5Text = GameObject.FindGameObjectWithTag("Planet5Text");

        List<GameObject> planetList = new List<GameObject>();
        planetList.Add(Planet1Text);
        planetList.Add(Planet2Text);
        planetList.Add(Planet3Text);
        planetList.Add(Planet4Text);
        planetList.Add(Planet5Text);

        GameObject SpaceshipWord = GameObject.FindGameObjectWithTag("SpaceshipWord");
        
        if (Planet1Text != null && Planet2Text != null && Planet3Text != null && Planet4Text != null && Planet5Text != null)
        {
            setupPlanets(planetList);
        }
        SpaceshipWord.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.correctAnswer].English;
    }

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

        // On collision, determines if correct answer, adds a point to the score, and updates the score text
        void FinaliseScoring(int value)
        {
            if (GameManager.Instance.correctAnswer == (GameManager.Instance.randomNumbersArray[value]))
            {
                GameManager.Instance.liveScore += 1;
                UpdateScoreText();
            }
            
            GameManager.Instance.getRandomArray();

            GameObject Planet1Text = GameObject.FindGameObjectWithTag("Planet1Text");
            GameObject Planet2Text = GameObject.FindGameObjectWithTag("Planet2Text");
            GameObject Planet3Text = GameObject.FindGameObjectWithTag("Planet3Text");
            GameObject Planet4Text = GameObject.FindGameObjectWithTag("Planet4Text");
            GameObject Planet5Text = GameObject.FindGameObjectWithTag("Planet5Text");

            List<GameObject> planetList = new List<GameObject>();
            planetList.Add(Planet1Text);
            planetList.Add(Planet2Text);
            planetList.Add(Planet3Text);
            planetList.Add(Planet4Text);
            planetList.Add(Planet5Text);

            GameObject SpaceshipWord = GameObject.FindGameObjectWithTag("SpaceshipWord");
            
            if (Planet1Text != null && Planet2Text != null && Planet3Text != null && Planet4Text != null && Planet5Text != null)
            {
                
                setupPlanets(planetList);
            }

            SpaceshipWord.GetComponent<Text>().text = StateController.wordList[GameManager.Instance.correctAnswer].English;

        }
    }

    // Checks if the text object is not null; updates the score text
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.liveScore; 
        }
    }

    // Sets up the planets with the words in the JSON file in the chosen language
    void setupPlanets(List<GameObject> planetList){
        switch(StateController.languageChoice){
            case "French":
                PlanetLangSetup.setupPlanetsFrench(planetList);
                break;
            case "Spanish":
                PlanetLangSetup.setupPlanetsSpanish(planetList);
                break;
            case "Italian":
                PlanetLangSetup.setupPlanetsItalian(planetList);
                break;
        }
    }
}
