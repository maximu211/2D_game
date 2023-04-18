using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    public Toggle FullScreenToggle;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currectResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currectResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currectResolutionIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SaveSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/Options.dat"))
            File.Delete(Application.persistentDataPath + "/Options.dat");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Options.dat");
        SaveData data = new SaveData();
        data.resolution = resolutionDropdown.value;
        data.fullscreen = Screen.fullScreen;
        bf.Serialize(file, data);
        file.Close();
    }
    public void OptionsLS()
    {
        LoadSettings(0);
        FullScreenToggle.isOn = Screen.fullScreen;
    }
    public void LoadSettings(int currentResolutionIndex)
    {

        if (File.Exists(Application.persistentDataPath + "/Options.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Options.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            resolutionDropdown.value = data.resolution;
            Screen.fullScreen = data.fullscreen;
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
            Screen.fullScreen = true;
        }
    }
}

[Serializable]
class SaveData
{
    public int resolution;
    public bool fullscreen;
}