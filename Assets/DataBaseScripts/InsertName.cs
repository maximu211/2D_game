using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class MySQLExample : MonoBehaviour {

    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    // Ініціалізуємо параметри підключення до бази даних
    private void InitDB()
    {
        server = "localhost";
        database = "database_name";
        uid = "user_name";
        password = "user_password";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    // Вставляємо дані у таблицю
    private void InsertData(string name)
    {
        string query = "INSERT INTO Player (Name) VALUES ('" + name + "');";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
    }

    private void Start () {
        InitDB();
        connection.Open();
        InsertData(" "); //insert data to BD
        connection.Close();
    }
}