using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient; //  MySQL Connector

public class GetMonster : MonoBehaviour
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
        command.CommandText = "SELECT * FROM Monster";
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int idMonster = reader.GetInt32(0);
            int HP = reader.GetInt32(1);
            bool Ranged = reader.GetBoolean(2);
            int MooveSpeed = reader.GetInt32(3);
            int Damage = reader.GetInt32(4);
            int AttackSpeed = reader.GetInt32(5);
            int MonsterSkillId = reader.GetInt32(6);
            string NameMonster = reader.GetString(7);

            Debug.Log("idMonster: " + idMonster + ", NameMonster: " + NameMonster + ", Health: " + HP + ", Damage: " + Damage + ", Speed: " + MooveSpeed + ", Ranged: " + Ranged + ", AttackSpeed: " +AttackSpeed + ", MonsterSkillId" + MonsterSkillId);
        }
    }

    private void CloseConnection()
    {
        connection.Close();
    }
}