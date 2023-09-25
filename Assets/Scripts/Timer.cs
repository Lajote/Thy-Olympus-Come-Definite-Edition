using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{


    public float startTime = 0f; // The starting time in seconds
    private float currentTime;  // The current time in seconds
    public Text timerText;
    public int minutes;
    public int seconds;
    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimerText();
    }

    void UpdateTimerText() 
    {
        try
        {
            minutes = Mathf.FloorToInt(currentTime / 60f);
            seconds = Mathf.FloorToInt(currentTime % 60f);

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Update the Text component with the formatted time
            timerText.text = timerString;
        }
        catch (Exception)
        {

        }

    }


}
