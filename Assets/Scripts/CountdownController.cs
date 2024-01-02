using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    int countdownTime = 120;
    public Text countdownDisplay;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer();
    }

    void countdownTimer()
    {
        if (countdownTime > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countdownTime);
            countdownDisplay.text = "Timer: " + spanTime.Minutes + ":" + spanTime.Seconds; ;
            countdownTime--;
            Invoke("countdownTimer", 1.0f);
        }

        else
        {
            countdownDisplay.text = "GAME OVER!";
        }
    }
}
