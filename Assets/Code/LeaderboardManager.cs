using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public PlayerDataList playerList;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Leaderboard");
        playerList = JsonUtility.FromJson<PlayerDataList>(textAsset.text); 
        List<PlayerData> sortedList = new List<PlayerData>(playerList.players);
        sortedList.Sort((player1, player2) => player2.score.CompareTo(player1.score));

        foreach (PlayerData player in sortedList)
        {
            Debug.Log("Name: " + player.name + ", Score: " + player.score);
        }
        
        
    }

    
    void Update()
    {
        
    }
}




