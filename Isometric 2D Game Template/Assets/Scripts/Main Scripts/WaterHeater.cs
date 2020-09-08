using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeater : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("WaterHeater", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("WaterHeater") == 1)
        {
            transform.GetChild(1).transform.GetComponent<SpriteRenderer>().color = Color.blue;
        }
	}

    public void Upgrade1()
    {
        if (PlayerPrefs.GetInt("WaterHeater") < 1)
        {
            int x = PlayerPrefs.GetInt("WaterHeater");
            x++;
            PlayerPrefs.SetInt("WaterHeater", x);
        }
    }
}
