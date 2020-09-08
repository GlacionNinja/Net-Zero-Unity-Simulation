using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timing : MonoBehaviour
{
    public int time;
    public int date;
    private float day;
    private float month;
    private int year;
    private int paceOfYourDay;

    public Text Date;
    public Text Time;
    private String dateLine;
    private String timeLine;
    private String[] months = new String[] {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

    private void Start()
    {
        paceOfYourDay = 1;

        time = PlayerPrefs.GetInt("Time");
        date = PlayerPrefs.GetInt("Date");

        StartCoroutine(UpdateTime());
    }

    private void Update()
    {         
        float day2 = Mathf.Floor(date / 100) % 100;
        float month2 = (Mathf.Floor(date / 10000));
        float year2 = date % 100;
    
        dateLine = months[Mathf.RoundToInt(month2) - 1];

        if (year >= 10)
          dateLine = dateLine + " " + day2 + ", 20" + year;
        if (year < 10)
            dateLine = dateLine + " " + day2 + ", 200" + year;

        Date.text = dateLine;

        int t = time;
        
        if (t < 1200)
        {
            if (t < 100)
            {
                if (time % 100 > 9)
                    timeLine = ("12:" + time % 100 + " AM");

                if (time % 100 <= 9)
                    timeLine = ("12:0" + time % 100 + " AM");
            }

            else
            {
                if (time % 100 > 9)
                    timeLine = Mathf.RoundToInt(Mathf.Floor(time / 100)) + ":" + time % 100 + " AM";

                if (time % 100 <= 9)
                    timeLine = Mathf.RoundToInt(Mathf.Floor(time / 100)) + ":0" + time % 100 + " AM";
            }
        }

        if (t > 1200)
        {
            if (t < 1300)
            {
                if ((time - 1200) % 100 > 9)
                    timeLine = ("12:" + (time - 1200) % 100 + " PM");

                if ((time - 1200) % 100 <= 9)
                    timeLine = ("12:0" + (time - 1200) % 100 + " PM");
            }

            else
            {
                if ((time - 1200) % 100 > 9)
                    timeLine = Mathf.RoundToInt(Mathf.Floor((time - 1200) / 100)) + ":" + (time - 1200) % 100 + " PM";

                if ((time - 1200) % 100 <= 9)
                    timeLine = Mathf.RoundToInt(Mathf.Floor((time - 1200) / 100)) + ":0" + (time - 1200) % 100 + " PM";
            }
        }

        Time.text = timeLine;
    }

    private IEnumerator UpdateTime()
    {
        yield return new WaitForSeconds(0.001f);
        time += paceOfYourDay;

        if (time % 100 >= 60)
        {
            time = time + 40;
        }

        if (Mathf.Floor(time/100) >= 24)
        {
            UpdateDay();
            time = 0000;
        }

        PlayerPrefs.SetInt("Time", time);

        StartCoroutine(UpdateTime());
    }
    
    private void UpdateDay()
    {
        day = Mathf.Floor(date/100) % 100;
        month = (Mathf.Floor(date / 10000));
        year = date % 100;

        day++;

        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if (day > 31)
            {
                day = 1;
                month++;
            }
        }

        if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            if (day > 30)
            {
                day = 1;
                month++;
            }
        }

        if (month == 2)
        {
            if (year % 4 == 0 && day > 29)
            {
                day = 1;
                month++;
            }
            if (year % 4 != 0 && day > 28)
            {
                day = 1;
                month++;
            }
        }

        if (month > 12)
        {
            day = 1;
            month = 1;
            year++;
        }

        date = Mathf.RoundToInt(month) * 10000 + Mathf.RoundToInt(day) * 100 + Mathf.RoundToInt(year);
        PlayerPrefs.SetInt("Date", date);
    }
}
