using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{

    public TextAsset textJSON;

    //class for each player
    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int mana;
    }

    //array of players
    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList playerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        playerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
