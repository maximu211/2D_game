using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int save;
    public void PlayGame()
    {
        DataHolder._saveNumber = save;
        SceneManager.LoadScene("Level");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
