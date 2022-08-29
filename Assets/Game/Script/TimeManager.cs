using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public DateTime startTime;
    public DateTime endTime;
    public TimeSpan timeSpent;

    public int min;
    public int sec;
    void Start()
    {
        startTime = System.DateTime.Now;
    }

    void Update()
    {
        if (GameManager.instance.play)
        {
            timeSpent = DateTime.Now - startTime;
            min = timeSpent.Minutes;
            sec = timeSpent.Seconds;
            GameManager.instance.TimeText.text = "Time Elapsed " + min.ToString("00") + " : " + sec.ToString("00");
        }
    }
}
