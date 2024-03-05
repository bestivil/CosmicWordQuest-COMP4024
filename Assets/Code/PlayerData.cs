using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}


[System.Serializable]
public class PlayerDataList
{
    public PlayerData[] players;
}