using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text gameTimerText;
    float gameTimer = 0f;
    void Update()
    {
        gameTimer += Time.deltaTime;

        int seconds = (int)(gameTimer % 60);
        int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer / 3600) % 24;
        gameTimerText.text = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

    }
}
