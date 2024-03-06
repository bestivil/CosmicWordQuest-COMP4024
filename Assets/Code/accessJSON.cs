using UnityEngine;

/// <summary>
/// Class used to read the JSON word data of different translations
/// </summary>
public class AccessJSON : MonoBehaviour
{   
    public TextAsset wordsJSON;
    
    [System.Serializable]
    public class Word{
        public string English;
        public string French;
        public string Spanish;
        public string Italian;
    }

    /// <summary>
    /// Wrapper class around the words array, used for reading in data
    /// </summary>
    [System.Serializable]
    public class WordListWrapper{
        public Word[] words;
    }
    // Initalise instance of WordListWrapper
    public WordListWrapper wordListWrapper = new();
    
    /// <summary>
    /// Converts all the words in the JSON file to a list of words stored in StateController
    /// </summary>
    void Start()
    {
        wordListWrapper = JsonUtility.FromJson<WordListWrapper>("{\"words\":" + wordsJSON.text + "}");
        StateController.wordList = wordListWrapper.words;
    }
}
