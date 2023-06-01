using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    private int healt;
    public int type;
    SavesData save = new SavesData();
    void Start()
    {
        string filePath = Application.persistentDataPath + "/save" + DataHolder._saveNumber + ".dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
        save = (SavesData)bf.Deserialize(file);
        file.Close();
        type = save.characterClass;
    }

    void Update()
    {

    }
}
