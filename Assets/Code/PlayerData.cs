using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int score;
    public string name;
}


[System.Serializable]
public class PlayerDataList
{
    public List<PlayerData> players;
}