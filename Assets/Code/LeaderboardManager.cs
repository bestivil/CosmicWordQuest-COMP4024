using System.Collections;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manages the Leaderboard scene
/// </summary>
public class LeaderboardManager : MonoBehaviour
{
    public PlayerDataList playerList; //stores an array of PlayerData

    string csvFilePath;
    
    public GameObject[] highscoreTexts = new GameObject[5];

    public PlayerData[] sortedList;

    /// <summary>
    /// Loads the CSV data of usernames and scores and sorts them by score to select top 5 scores
    /// </summary>
    void Start()
    {
        InitHighScoreText();
        
        csvFilePath = Path.Combine(Application.persistentDataPath,"ScoresCSV.csv");
        
        // Check if file exists
        if (!File.Exists(csvFilePath))
        {
            // If file doesn't exist, create it
            using (StreamWriter sw = File.CreateText(csvFilePath))
            {
                // Write headers if needed
                sw.WriteLine("name,score");
                sw.WriteLine("Lucas,1");
            }

        }
        string[] lines = File.ReadAllLines(csvFilePath);

        // Skip the first line (headers) if exists
        if (lines.Length > 0)
            lines = lines.Skip(1).ToArray();

        playerList.players = new PlayerData[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            playerList.players[i] = new PlayerData
            {
                name = fields[0],
                score = int.Parse(fields[1])
            };
        }
        
        PlayerData[] sortedList = SelectTop5();
        
        DisplayTopScores(sortedList);
        //reload to display new written changes to the file
        StartCoroutine(ReloadSceneEvery5Seconds());

    }
    /// <summary>
    /// get the GameObjects of each Text
    /// </summary>
    void InitHighScoreText(){
        highscoreTexts[0] = GameObject.FindGameObjectWithTag("Text1");
        highscoreTexts[1] = GameObject.FindGameObjectWithTag("Text2");
        highscoreTexts[2] = GameObject.FindGameObjectWithTag("Text3");
        highscoreTexts[3] = GameObject.FindGameObjectWithTag("Text4");
        highscoreTexts[4] = GameObject.FindGameObjectWithTag("Text5");
    }

    /// <summary>
    /// select top 5 players from the player array
    /// the top scores are the last elements of the array
    /// </summary>
    /// <returns>returns the sorted array</returns>
    PlayerData[] SelectTop5(){
        sortedList = playerList.players.OrderBy(PlayerData=>PlayerData.score).ToArray();

        return sortedList;
    }
    /// <summary>
    /// Display top 5 or less scores and their usernames to the scene
    /// </summary>
    /// <param name="sortedList">array of PlayerData sorted by the scores</param>
    void DisplayTopScores(PlayerData[] sortedList){
        int listLength = sortedList.Length;
        for(int i=0; i<listLength; i++){

            if(i>4){
                break; //we cant go further in the highscoreTexts array, but i < listLength is still set
                // as that list could have less than 5 elements
            }
            string name = sortedList[listLength-1-i].name; // take from the end of the array
            int score = sortedList[listLength-1-i].score;
            int currentPosition = i+1;

            highscoreTexts[i].GetComponent<Text>().text = currentPosition.ToString() + ". Name = " 
                + name + "; Score = " + score.ToString();
        }
    }

    /// <summary>
    /// reloads the scene every 5 seconds to display the most recent score of the user (if they are top 5)
    /// </summary>
    /// <returns>returns IEnumerator for the couroutine</returns>
     IEnumerator ReloadSceneEvery5Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
