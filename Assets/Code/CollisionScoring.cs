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
        else
        {
            Debug.LogError("No game object with tag 'ScoreText' found.");
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
            /*
            var languageChoice = StateController.languageChoice;

            Type wordType = typeof(Word);
            PropertyInfo property = wordType.GetProperty(languageChoice);

            */
            setupPlanets(planetList);

            //Planet1Text.GetComponent<Text>().text = (string)property.GetValue(StateController.wordList[GameManager.Instance.randomNumbersArray[0]]);
        }


        Debug.Log("correct answer index = " + GameManager.Instance.correctAnswer);
        Debug.Log("English word = " + StateController.wordList[GameManager.Instance.correctAnswer].English);

        Debug.Log("Spaceship word = " + SpaceshipWord);
        Debug.Log("planet5 text = " + Planet5Text);

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

    void setupPlanets(List<GameObject> planetList){
        switch(StateController.languageChoice){
            case "French":
                setupPlanetsFrench(planetList);
                break;
            case "Spanish":
                setupPlanetsSpanish(planetList);
                break;
            case "Italian":
                setupPlanetsItalian(planetList);
                break;
        }
    }

    void setupPlanetsFrench(List<GameObject> planetList){
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].French;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].French;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].French;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].French;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].French;
    }

    void setupPlanetsSpanish(List<GameObject> planetList){
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Spanish;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Spanish;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Spanish;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Spanish;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Spanish;
    }

    void setupPlanetsItalian(List<GameObject> planetList){
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Italian;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Italian;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Italian;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Italian;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Italian;
    }
}
