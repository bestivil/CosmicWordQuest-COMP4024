using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// Class responsible for storing game information and controlling the game
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int level = 1;
    public float currentLevelTime = 30f; // Default timing for the level

    public string scoreUser = "0"; // used for the text to be shown in scene

    public int liveScore = 0; //keeps the int value of score updated

    public int[] randomNumbersArray;
    public int correctAnswer = 0;
    public PlayerData player = new();

    private Text levelText; 

    

    /// <summary>
    /// When the game starts, the GameManager is created
    /// </summary>
    void Awake()
    {
        
        // Make sure the GameManager persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        // Ensure there is only one GameManager
        else if (Instance != this)
        {
            Destroy(gameObject); 
        }
    
        // Calls the number randomiser
        GetRandomArray();

        GameObject levelObject = GameObject.FindGameObjectWithTag("CurrentLevel");
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");

        if (levelObject != null && timerObject != null)
        {
            levelText = levelObject.GetComponent<Text>();
            levelText.text = "Level: " + GameManager.Instance.level;
        } 

    }

    /// <summary>
    /// Called each time level is finished
    /// </summary>
    public void LevelCompleted()
    {
        level++;

        // if level is above 6, update user score data and 
        if (level >= 6)
        {
            GameObject scoreTextObject = GameObject.FindGameObjectWithTag("ScoreText");
            Debug.Log("Score Text Object: " + scoreTextObject);
            if (scoreTextObject != null)
            {
                scoreUser = scoreTextObject.GetComponent<Text>().text;
            }
            player.score = liveScore;

            FinalScoreDialog();
        }

        //adjusts time for new level, gets random words and reloads this scene
        else
        {
            AdjustLevelTiming();
            GetRandomArray();
            LoadCurrentScene();
        }
    }
    
    /// <summary>
    /// For every level, the total time is reduced by 5 seconds, so 30,25,20 etc.
    /// </summary>
    void AdjustLevelTiming()
    {
        currentLevelTime = Mathf.Max(5, currentLevelTime - 5);
    }
    /// <summary>
    /// reloads the scene
    /// </summary>
    public void LoadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    /// <summary>
    /// load the HighScoreScreen scene
    /// </summary>
    void FinalScoreDialog()
    {
        SceneManager.LoadScene("HighScoreScreen");
    }
    /// <summary>
    /// load Leaderboard scene if Leaderboard icon is pressed
    /// </summary>
    public void LoadLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    /// <summary>
    /// get a random array of unique indices that will then be used to index into the word list to get random words, 
    /// and store correct answer index
    /// </summary>
    public void GetRandomArray()
    {
        List<int> randIntArray = new();
        while(randIntArray.Count < 5){
            var uniqueRandom = Random.Range(0,150);
            
            // ensures number generated aren't repeated
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

    /// <summary>
    /// On HighScore screen, sets the player's name, then automatically saved to the CSV file
    /// </summary>
    /// <param name="name">user name</param>
    public void SetNames(string name)
    {
        player.name = name;
        SaveToFile();
        
    }
    /// <summary>
    /// opens the CSV file, runs the stream writer to save the new data
    /// </summary>
    void SaveToFile()
    {
        // saving data to CSV file
        var filename = Application.persistentDataPath + "/ScoresCSV.csv";
        
        // Check if file exists
        if (!File.Exists(filename))
        {
            // If file doesn't exist, create it
            using (StreamWriter sw = File.CreateText(filename))
            {
                // Write headers if needed
                sw.WriteLine("name,score");
                sw.WriteLine("Lucas,1");
            }

        }
        // Append new data to the existing file
        using (StreamWriter sw = File.AppendText(filename))
        {
            sw.WriteLine(player.name + "," + player.score);
        }
    }
}
