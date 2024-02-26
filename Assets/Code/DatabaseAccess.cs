using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

public class DatabaseAccess : MonoBehaviour
{
    //might be bad to store password in plain text in source code like this
    MongoClient client = 
        new MongoClient("mongodb+srv://group13:HRXCeKCzfRSIDzTn@cluster1.jrzdo3h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster1");
    
    IMongoDatabase database;
    IMongoCollection<BsonDocument>collection;

    // Start is called before the first frame update
    void Start()
    {
        database = client.GetDatabase("TestConnection");
        collection = database.GetCollection<BsonDocument>("TestConnectionCollection");

        // testing connection - adding to DB

        var document = new BsonDocument {{"username",100}};
        collection.InsertOne(document);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
