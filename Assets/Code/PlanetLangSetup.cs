using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

// Class called by GameManager to set up the planets with the correct language
public class PlanetLangSetup : MonoBehaviour
{
    public static void setupPlanetsFrench(List<GameObject> planetList)
    {
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].French;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].French;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].French;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].French;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].French;
    }

    public static void setupPlanetsSpanish(List<GameObject> planetList)
    {
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Spanish;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Spanish;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Spanish;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Spanish;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Spanish;
    }

    public static void setupPlanetsItalian(List<GameObject> planetList)
    {
            planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Italian;
            planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Italian;
            planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Italian;
            planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Italian;
            planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Italian;
    }
}
