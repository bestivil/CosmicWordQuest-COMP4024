/// <summary>
/// Class that stores the name and score of the player
/// </summary>
[System.Serializable]
public class PlayerData
{
    public string name;
    public int score;
}


/// <summary>
/// Class that stores an array of PlayerData used to read from CSV
/// </summary>
[System.Serializable]
public class PlayerDataList
{
    public PlayerData[] players;
}