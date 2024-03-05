using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accessJSON : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private List<int> randIntArray = new List<int>();
    public TextAsset wordsJSON;

    public static int correctAnswer;
    public static int[] randomNumbersArray;
    
    [System.Serializable]
    public class Word{
        public string English;
        public string French;
        public string Spanish;
        public string Italian;
    }


    [System.Serializable]
    public class WordListWrapper{
        public Word[] words;
    }
    // Initalise instance of WordListWrapper
    public WordListWrapper wordListWrapper = new WordListWrapper();
    
    // Converts all the words in the JSON file to a list of words
    void Start()
    {
        wordListWrapper = JsonUtility.FromJson<WordListWrapper>("{\"words\":" + wordsJSON.text + "}");
        StateController.wordList = wordListWrapper.words;
    }
}
