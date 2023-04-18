using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int healt;
    public Sprite[] spriteHero = new Sprite[2];
    public SpriteRenderer spritePlayer;
    SavesData save = new SavesData();
    void Start()
    {
        string filePath = Application.persistentDataPath + "/save" + DataHolder._saveNumber + ".dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open);
        save = (SavesData)bf.Deserialize(file);
        file.Close();
        Debug.Log(DataHolder._saveNumber);
        Debug.Log(save.characterClass - 1);
        spritePlayer.sprite = spriteHero[save.characterClass - 1];
    }

    void Update()
    {

    }
}
