using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int level = 1;
    public float currentLevelTime = 10f; // Default timing for the level
    private GameObject usernameDialogObject;

    private string nameUser;
    public string scoreUser = "0";

    public int liveScore = 0;

    public int[] randomNumbersArray;
    public int correctAnswer = 0;
    public PlayerData player = new PlayerData();

    

    void Awake()
    {
        
        
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure the GameManager persists across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensure there is only one GameManager
        }

        getRandomArray();

        

        
    }

    void addDatabase()
    {
        // Add the user's name and score to the database
    }

    public void setNames(string name)
    {
        player.name = name;
        SaveToFile();
        
    }

    public void LevelCompleted()
    {
        level++;


        if (level >= 11)
        {
            GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
            if (scoreTextObject != null)
            {
                scoreUser = scoreTextObject.GetComponent<Text>().text;
            }
            player.score = liveScore;

        

            
            FinalScoreDialog();
        }
        else
        {
            AdjustLevelTiming();
            getRandomArray();
            LoadCurrentScene();
        }

        
    }

    

    void AdjustLevelTiming()
    {
        
        currentLevelTime = Mathf.Max(5, currentLevelTime - 0);
    }

    void LoadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void FinalScoreDialog()
    {
       
        SceneManager.LoadScene("HighScoreScreen");
    }

    public void LoadLeaderboard()
    {
        
        SceneManager.LoadScene("Leaderboard");
        
    }

    //generates a random array of words to pick from the word list
    //want to make sure they are unique
    void getRandomArray()
    {
        List<int> randIntArray = new List<int>();
        while(randIntArray.Count < 5){
            var uniqueRandom = Random.Range(0,150);
            
            // this is to make sure the number we generate is not already inside of this array
            while(randIntArray.Contains(uniqueRandom)){
                uniqueRandom = Random.Range(0,150);
            }
            randIntArray.Add(uniqueRandom);
            
        }
        randomNumbersArray = randIntArray.ToArray();
        //store the index to which we find the word in list
        //it is exclusive for array Length as being max value
        correctAnswer = randomNumbersArray[Random.Range(0, randomNumbersArray.Length)];
    }
    
    void SaveToFile()
    {
        // saving data to CSV file
        var filename = Application.dataPath + "/Database/ScoresCSV.csv";
        TextWriter textWriter = new StreamWriter(filename,true);
        textWriter.WriteLine(player.name + "," + player.score);
        textWriter.Close();
    }
}
