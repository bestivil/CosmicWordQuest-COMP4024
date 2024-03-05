using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.Common;

public class DatabaseAccess : MonoBehaviour
{
    MongoClient client = 
        new MongoClient("mongodb+srv://group13:HRXCeKCzfRSIDzTn@cluster1.jrzdo3h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster1");
    
    IMongoDatabase database;
    IMongoCollection<BsonDocument>collection;

    async void Start()
    {
        database = client.GetDatabase("wordTranslations");
        collection = database.GetCollection<BsonDocument>("wordTranslations");

        Debug.Log(collection);

        var documents = await collection.Find(new BsonDocument()).ToListAsync();
        Debug.Log(documents);

        var allWords = collection.FindAsync(new BsonDocument());
        var allWordsAwaited = await allWords;

        
    }
}
