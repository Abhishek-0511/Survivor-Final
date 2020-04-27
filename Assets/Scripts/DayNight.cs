using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNight : MonoBehaviour
{
    public Light sun;
    public float secondsInFullDay = 120f;
    private float days;
    public float currentTimeOfDay = 0;
    public float timeMultiplier = 1f;
    public Text hour, minutes,day;

    void Start()
    {
        days = 1;
    }

    void Update()
    {
        UpdateSun();
        UpdateClock();
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
            days++;
        }
    }
    void UpdateClock()
    {
        float currentHour = 24 * currentTimeOfDay;
        float currentMinute = 60 * (currentHour - Mathf.Floor(currentHour));
        hour.text = "Time-"+currentHour.ToString("0")+":";
        minutes.text = currentMinute.ToString("0");
        day.text = "Day no:"+days.ToString("0");

    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
    }
}

