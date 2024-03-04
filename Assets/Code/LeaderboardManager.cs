using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeaderboardManager : MonoBehaviour
{
    public PlayerDataList playerList;

    public TextAsset CSVData;

    // Start is called before the first frame update
    void Start()
    {
        //using CSV file now

        //get the data in that file and split it by commas and new lines

        Debug.Log("Got here");

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
    }
}




