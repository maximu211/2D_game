using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Saves : MonoBehaviour
{
    public int saveIndex;
    public GameObject Error;
    public Text errorText;
    public Toggle Knight, Archer;
    public InputField InputName;
    public Button ButtonSave;
    private SavesData saves = new SavesData();

    public GameObject[] EmptySave = new GameObject[3];
    public GameObject[] FilledSave = new GameObject[3];


    public Text[] stats = new Text[9]; 

    void Start()
    {
        LoadSaves();
    }

    public void LoadSaves()
    {
        for (int i = 1; i < 4; i++)
        {
            int textIndex = (i - 1) * 3;
            string filePath = Application.persistentDataPath + "/save" + i + ".dat";
            if (File.Exists(filePath))
            {
                EmptySave[i - 1].SetActive(false);
                FilledSave[i - 1].SetActive(true);
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(filePath, FileMode.Open);
                SavesData save = (SavesData)bf.Deserialize(file);
                file.Close();
                stats[textIndex].text = save.name;
                textIndex++;
                if (save.characterClass == 1)
                    stats[textIndex].text = "Knight";
                else if (save.characterClass == 2)
                    stats[textIndex].text = "Archer";
                Debug.Log(save.characterClass);
                textIndex++;
                if (save.time == 0.0f)
                    stats[textIndex].text = "-";
                else
                    stats[textIndex].text = save.time.ToString();
            }
        }
    }


    public void SavesIndex(int Index)
    {
        saveIndex = Index;
    }
    public void selectKnight(bool ToggleKnight)
    {
        if(ToggleKnight)
        {
            Archer.isOn = false;
            saves.characterClass = 1;
        }
    }
    public void selectArcher(bool ToggleArcher)
    {
        if (ToggleArcher)
        {
            Knight.isOn = false;
            saves.characterClass = 2;
        }
    }

    public void InputNames()
    {
        saves.name = InputName.text;
    }

    public void SaveData()
    {
        if(saves.name == null || (InputName.text == null) || saves.name == "")
        {
            Error.SetActive(true);
            Lock(false);
            errorText.text = "Error!\n Input name hero!";
        }
        else if (saves.characterClass == 0 || (Knight.isOn == false && Archer.isOn == false) )
        {
            Error.SetActive(true);
            Lock(false);
            errorText.text = "Error!\n Select character class!";
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/save" + saveIndex + ".dat");
            saves.time = 0.0f;
            bf.Serialize(file, saves);
            file.Close();
            ResetSaves();
            LoadSaves();
            GameObject NewSave = GameObject.Find("NewSave");
            NewSave.SetActive(false);
        }
    }

    public void RemoveSave(int saveIndex)
    {
        File.Delete(Application.persistentDataPath + "/save" + saveIndex + ".dat");
        EmptySave[saveIndex - 1].SetActive(true);
        FilledSave[saveIndex - 1].SetActive(false);
    }


    public void ResetSaves()
    {
        saves.name = null;
        saves.characterClass = 0;
        Knight.isOn = false;
        Archer.isOn = false;
        InputName.text = null;
        saveIndex = 0;
    }

   

    // Update is called once per frame

    public void Lock(bool locked)
    {
        Knight.interactable= locked;
        Archer.interactable = locked;
        Knight.interactable = locked;
        InputName.interactable = locked;
        ButtonSave.interactable = locked;
    }
}

[Serializable]
class SavesData
{
    public int  characterClass;
    public float time;
    public string name;
}
