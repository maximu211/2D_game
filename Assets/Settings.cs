using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    int currectResolutionIndex = 0;
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currectResolutionIndex = 0;

        for(int i = 0; i< resolutions.Length; i++)
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
        currectResolutionIndex = resolutionIndex;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreferens", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreferens", System.Convert.ToInt32(Screen.fullScreen));
        Screen.SetResolution(resolutions[currectResolutionIndex].width, resolutions[currectResolutionIndex].height, Screen.fullScreen);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreferens"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreferens");
        else
            resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullScreenPreferens"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreferens"));
        else
            Screen.fullScreen = true;
    }
}
