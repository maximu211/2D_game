using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient; //  MySQL Connector

public class GetPlayer : MonoBehaviour
{

    private MySqlConnection connection;
    private string serverName = "localhost"; // Database server Name
    private string dbName = "myDatabase"; // DB name
    private string userName = "myUsername"; // user Name 
    private string password = "myPassword"; // password to DB

    //functions defenition
    private void Start()
    {
        ConnectToDatabase();
        GetData();
        CloseConnection();
    }

    //Conect to DB
    private void ConnectToDatabase()
    {
        string connectionString = "Server=" + serverName + ";Database=" + dbName + ";Uid=" + userName + ";Pwd=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
    }

    //Getting data from DB
    private void GetData()
    {
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Player";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int idPlayer = reader.GetInt32(0);
            string Name = reader.GetString(1);
            int CharacterId = reader.GetInt32(2);
            int CharacterLevel = reader.GetInt32(2);
            Debug.Log("idPlayer: " + idPlayer + ", Name: " + Name + ", CharacterId: " + CharacterId + ", CharacterLevel: " + CharacterLevel);
        }
    }

    private void CloseConnection()
    {
        connection.Close();
    }
}