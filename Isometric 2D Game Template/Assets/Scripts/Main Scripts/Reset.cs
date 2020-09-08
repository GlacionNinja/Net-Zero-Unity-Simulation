using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Reset") == 1)
        {
            PlayerPrefs.SetInt("Time", 0700);
            PlayerPrefs.SetInt("Date", 010118);
            PlayerPrefs.SetInt("Reset", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
