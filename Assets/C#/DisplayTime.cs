using TMPro;
using UnityEngine;
using System;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;
     
    private float currentTime;

    private int currentDay;
    private int currentMonth;
    private int currentYear;
    private int currentHour;
    private int currentMinute;
    private float currentSecond;  
    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    { 
        DateTime now = DateTime.Now;

        currentDay = now.Day;
        currentMonth = now.Month;
        currentYear = now.Year;

        currentHour = now.Hour;
        currentMinute = now.Minute; 
         
        UpdateDisplay(); 
    }

    void Update()
    {
        currentSecond += Time.deltaTime;
        if(currentSecond >= 60)
        {
            currentSecond -= 60;
            currentTime = currentMinute + (currentHour * 60) + 1;

            currentHour = Mathf.FloorToInt(currentTime /60);
            currentMinute = Mathf.FloorToInt(currentTime % 60);
             
            currentDay += currentHour >= 24 ? 1 : 0;
            UpdateDisplay(); 
        } 
    }

    private void UpdateDisplay()
    { 
        string formattedTime = string.Format("{0:D2}:{1:D2}  {2:00}.{3:00}.{4:00}",
            currentHour, currentMinute,
            currentDay, currentMonth, currentYear);

        if (timeText != null)
        {
            timeText.text = formattedTime;
        }
    }
}
