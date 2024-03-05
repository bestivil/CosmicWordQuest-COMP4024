using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates a PlayerData class that stores the name and score of the player
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}


// creates a PlayerDataList class that stores an array of PlayerData
[System.Serializable]
public class PlayerDataList
{
    public PlayerData[] players;
}