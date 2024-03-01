using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON : MonoBehaviour
{
    // Start is called before the first frame update
    
    public TextAsset wordsJSON;
    
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

    public WordListWrapper wordListWrapper = new WordListWrapper();
    
    
    void Start()
    {
        //wordList = JsonUtility.FromJson<List<Word>>(wordsJSON.text);


        wordListWrapper = JsonUtility.FromJson<WordListWrapper>("{\"words\":" + wordsJSON.text + "}");
        Word[] wordList = wordListWrapper.words;

        Debug.Log(wordList[0].Spanish);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
