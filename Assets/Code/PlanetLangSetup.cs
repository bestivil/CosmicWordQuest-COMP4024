using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Use UnityEngine.UI for the Text component

/// <summary>
/// Class called by GameManager to set up the planets with the correct language
/// </summary>
public class PlanetLangSetup : MonoBehaviour
{
        /// <summary>
        /// Sets up the planets for the French language using the random index array
        /// </summary>
        /// <param name="planetList">List of GameObject planets</param>
        public static void SetupPlanetsFrench(List<GameObject> planetList)
        {
                planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].French;
                planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].French;
                planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].French;
                planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].French;
                planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].French;
        }
        /// <summary>
        /// Sets up the planets for the Spanish language using the random index array
        /// </summary>
        /// <param name="planetList">List of GameObject planets</param>
        public static void SetupPlanetsSpanish(List<GameObject> planetList)
        {
                planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Spanish;
                planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Spanish;
                planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Spanish;
                planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Spanish;
                planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Spanish;
        }
        /// <summary>
        /// Sets up the planets for the Italian language using the random index array
        /// </summary>
        /// <param name="planetList">List of GameObject planets</param>
        public static void SetupPlanetsItalian(List<GameObject> planetList)
        {
                planetList[0].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[0]].Italian;
                planetList[1].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[1]].Italian;
                planetList[2].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[2]].Italian;
                planetList[3].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[3]].Italian;
                planetList[4].GetComponent<Text>().text = StateController.wordList[GameManager.Instance.randomNumbersArray[4]].Italian;
        }
}
