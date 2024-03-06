using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    public PlayerDataList playerList;

    public TextAsset CSVData;

    public GameObject[] highscoreTexts = new GameObject[5];

    public PlayerData[] sortedList;

    // Start is called before the first frame update
    void Start()
    {
        //using CSV file now

        //get the data in that file and split it by commas and new lines
        InitHighScoreText();

        string[] data = CSVData.text.Split(new string[] { ",", "\n"},StringSplitOptions.None);

        //determine how wide the data table is
        // 2 columns, and ignore first row as its just columns
        int dataTableSize = data.Length / 2 - 1;

        playerList.players = new PlayerData[dataTableSize];

        for(int i=0; i < dataTableSize; i++){
            playerList.players[i] = new PlayerData
            {
                name = data[2 * (i + 1)], // get the name by this maths
                score = int.Parse(data[2 *(i+1) + 1]) // score is the next part of the data entry
            };
        }
        PlayerData[] sortedList = SelectTop5();
        
        DisplayTopScores(sortedList);

        StartCoroutine(ReloadSceneEvery5Seconds());

    }

    void InitHighScoreText(){
        highscoreTexts[0] = GameObject.FindGameObjectWithTag("Text1");
        highscoreTexts[1] = GameObject.FindGameObjectWithTag("Text2");
        highscoreTexts[2] = GameObject.FindGameObjectWithTag("Text3");
        highscoreTexts[3] = GameObject.FindGameObjectWithTag("Text4");
        highscoreTexts[4] = GameObject.FindGameObjectWithTag("Text5");
    }

    //select top 5 players from the player list
    // the top scores are the last elements of the array
    PlayerData[] SelectTop5(){
        sortedList = playerList.players.OrderBy(PlayerData=>PlayerData.score).ToArray();

        return sortedList;
    }

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

     IEnumerator ReloadSceneEvery5Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
