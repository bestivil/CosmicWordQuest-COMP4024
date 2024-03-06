using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public static string languageChoice;

    public static StateController Instance;

    public static AccessJSON.Word[] wordList; // storing the word list for other classes

    public static int[] randomNumbersArray;
    public static int correctAnswer;

    void Start()
    {
        List<int> randIntArray = new List<int>();
        while(randIntArray.Count < 5){
            randIntArray.Add(UnityEngine.Random.Range(1, 149));
        }
        randomNumbersArray = randIntArray.ToArray();
        correctAnswer = randomNumbersArray[Random.Range(0, randomNumbersArray.Length)];
    }
}
