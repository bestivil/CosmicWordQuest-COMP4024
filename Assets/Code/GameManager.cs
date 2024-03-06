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
    public float currentLevelTime = 30f; // Default timing for the level
    private GameObject usernameDialogObject;

    private string nameUser;
    public string scoreUser = "0";

    public int liveScore = 0;

    public int[] randomNumbersArray;
    public int correctAnswer = 0;
    public PlayerData player = new PlayerData();

    private Text levelText; 

    

    // When the game starts, the GameManager is created
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
        getRandomArray();

        GameObject levelObject = GameObject.FindGameObjectWithTag("CurrentLevel");
        GameObject timerObject = GameObject.FindGameObjectWithTag("Timer");

        if (levelObject != null && timerObject != null)
        {
            levelText = levelObject.GetComponent<Text>();
            levelText.text = "Level: " + GameManager.Instance.level;
        } 

        



    }

    public void LevelCompleted()
    {
        level++;

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

        else
        {
            AdjustLevelTiming();
            getRandomArray();
            LoadCurrentScene();
        }
    }
    
    // For every level, the total time is reduced by 5 seconds, so 30,25,20 etc.
    void AdjustLevelTiming()
    {
        currentLevelTime = Mathf.Max(5, currentLevelTime - 5);
    }

    public void LoadCurrentScene()
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


    public void getRandomArray()
    {
        List<int> randIntArray = new List<int>();
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

    // On HighScore screen, sets the player's name, then automatically saved to the CSV file
    public void setNames(string name)
    {
        player.name = name;
        SaveToFile();
        
    }
    // opens the csv, runs the stream writer to save the data
    void SaveToFile()
    {
        // saving data to CSV file
        var filename = Application.dataPath + "/Database/ScoresCSV.csv";
        TextWriter textWriter = new StreamWriter(filename,true);
        textWriter.WriteLine(player.name + "," + player.score);
        textWriter.Close();
    }
}
