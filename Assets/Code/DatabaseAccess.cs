using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.Common;

public class DatabaseAccess : MonoBehaviour
{
    //might be bad to store password in plain text in source code like this
    MongoClient client = 
        new MongoClient("mongodb+srv://group13:HRXCeKCzfRSIDzTn@cluster1.jrzdo3h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster1");
    
    IMongoDatabase database;
    IMongoCollection<BsonDocument>collection;

    // Start is called before the first frame update
    async void Start()
    {
        database = client.GetDatabase("wordTranslations");
        collection = database.GetCollection<BsonDocument>("wordTranslations");

        Debug.Log(collection);

        /*
        Db = GameObject.FindGameObjectWithTag("RandomRecordEnglish1");
        if (Db != null)
        {
            GetRandomRecord()
        }

        */


        var documents = await collection.Find(new BsonDocument()).ToListAsync();
        Debug.Log(documents);

        //return (from p in collection.AsQueryable() select p["English"]).ToList();





        var allWords = collection.FindAsync(new BsonDocument());
        var allWordsAwaited = await allWords;

        //List<Word> words = new List<Word>();

        //foreach (var word in allWordsAwaited.ToList()){
        //    words.Add(Deserialize(word.ToString()));
       // }
        //return words;
    }
    /*
    public async Task<List>


    private Word Deserialize(string rawJson){

    }
    */


    // Update is called once per frame
    void Update()
    {
        
    }

    void GetRandomRecord()
    {
        
    }
}

/*
public class Word{

    public string 

}
*/