using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHandler : MonoBehaviour
{

    float timeInSeconds;
    float timeInMinutes;
    bool canCountTime;

    void Update()
    {
        if (canCountTime)
        {
            timeInSeconds += Time.deltaTime;
            if (timeInSeconds >= 60)
            {
                timeInSeconds = 0;
                timeInMinutes++;
            }
            // print(timeInMinutes + " : " + Math.Floor(timeInSeconds));
            UiManager.instance.UpdateTimerUi((float)Math.Floor(timeInMinutes), (float)Math.Floor(timeInSeconds));
        }
    }
    public void StartTime()
    {
        timeInSeconds = 0;
        timeInMinutes = 0;
        canCountTime = true;
    }
    public void PauseTime(bool active)
    {
        canCountTime = !active;
    }
}
