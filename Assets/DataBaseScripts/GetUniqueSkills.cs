using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient; //  MySQL Connector

public class UniqueSkills : MonoBehaviour
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
        command.CommandText = "SELECT * FROM UniqueSkills";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int idUniqueSkills = reader.GetInt32(0);
            string SkillName = reader.GetString(1);
            string Type = reader.GetString(2);
            int Power = reader.GetInt32(3);
            string Description = reader.GetString(4);
            int Cooldown = reader.GetInt32(5);
            Debug.Log("idUniqueSkills: " + idUniqueSkills + ", SkillName: " + SkillName + ", Type: " + Type + ", Power: " + Power + ", Description: " + Description+ ", Cooldown :" + Cooldown);
        }
    }

    private void CloseConnection()
    {
        connection.Close();
    }
}