using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseInfo : MonoBehaviour {

    public Text solarPanels;
    public Button WindowButton;
    public Button ACButton;

    public Sprite H0;
    public Sprite H1;
    public Sprite H2;
    public Sprite H3;
    public Sprite H4;
    public Sprite H5;
    public Sprite H6;
    public Sprite H7;
    public Sprite H8;
    public Sprite H9;
    public Sprite H10;
    public Sprite H11;
    public Sprite H12;
    public Sprite H13;
    public Sprite H14;
    public Sprite H15;
    public Sprite H16;
    public Sprite H17;
    public Sprite H18;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("OpenWindows") == 1)
        {
            WindowButton.transform.GetComponent<Image>().color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("OpenWindows") == 0)
        {
            WindowButton.transform.GetComponent<Image>().color = Color.white;
        }

        if (PlayerPrefs.GetInt("AC") == 1)
        {
            ACButton.transform.GetComponent<Image>().color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("AC") == 0)
        {
            ACButton.transform.GetComponent<Image>().color = Color.white;
        }

        Debug.Log(PlayerPrefs.GetInt("OpenWindows") + " Window " + PlayerPrefs.GetInt("AC") + " AC ");
    }
	
	// Update is called once per frame
	void Update () {
        solarPanels.text = PlayerPrefs.GetInt("SolarPanel").ToString();

        SpriteRenderer child = transform.GetChild(1).transform.GetComponent<SpriteRenderer>();

        if (PlayerPrefs.GetInt("SolarPanel") == 0)
            child.sprite = H0;

        if (PlayerPrefs.GetInt("SolarPanel") == 1)
            child.sprite = H1;

        if (PlayerPrefs.GetInt("SolarPanel") == 2)
            child.sprite = H2;

        if (PlayerPrefs.GetInt("SolarPanel") == 3)
            child.sprite = H3;

        if (PlayerPrefs.GetInt("SolarPanel") == 4)
            child.sprite = H4;

        if (PlayerPrefs.GetInt("SolarPanel") == 5)
            child.sprite = H5;

        if (PlayerPrefs.GetInt("SolarPanel") == 6)
            child.sprite = H6;

        if (PlayerPrefs.GetInt("SolarPanel") == 7)
            child.sprite = H7;

        if (PlayerPrefs.GetInt("SolarPanel") == 8)
            child.sprite = H8;

        if (PlayerPrefs.GetInt("SolarPanel") == 9)
            child.sprite = H9;

        if (PlayerPrefs.GetInt("SolarPanel") == 10)
            child.sprite = H10;

        if (PlayerPrefs.GetInt("SolarPanel") == 11)
            child.sprite = H11;

        if (PlayerPrefs.GetInt("SolarPanel") == 12)
            child.sprite = H12;

        if (PlayerPrefs.GetInt("SolarPanel") == 13)
            child.sprite = H13;

        if (PlayerPrefs.GetInt("SolarPanel") == 14)
            child.sprite = H14;

        if (PlayerPrefs.GetInt("SolarPanel") == 15)
            child.sprite = H15;

        if (PlayerPrefs.GetInt("SolarPanel") == 16)
            child.sprite = H16;

        if (PlayerPrefs.GetInt("SolarPanel") == 17)
            child.sprite = H17;

        if (PlayerPrefs.GetInt("SolarPanel") == 18)
            child.sprite = H18;
    }

    public void OpenWindows()
    {
        int bob = 0;
        if (PlayerPrefs.GetInt("OpenWindows") == 0 & bob == 0)
        {
            bob = 1;
            PlayerPrefs.SetInt("OpenWindows", 1);
            WindowButton.transform.GetComponent<Image>().color = Color.cyan;
        }

        if (PlayerPrefs.GetInt("OpenWindows") == 1 & bob == 0)
        {
            bob = 1;
            PlayerPrefs.SetInt("OpenWindows", 0);
            WindowButton.transform.GetComponent<Image>().color = Color.white;
        }
    }

    public void TurnOnAC()
    {
        if (PlayerPrefs.GetInt("AC") == 0)
        {
            PlayerPrefs.SetInt("AC", 1);
            ACButton.transform.GetComponent<Image>().color = Color.cyan;
        }

        else
        {
            PlayerPrefs.SetInt("AC", 0);
            ACButton.transform.GetComponent<Image>().color = Color.white;
        }
    }

    public void IncreasePanel()
    {
        if (PlayerPrefs.GetInt("SolarPanel") < 18)
        {
            int s = PlayerPrefs.GetInt("SolarPanel");
            s++;
            PlayerPrefs.SetInt("SolarPanel", s);
        }
    }

    public void DecreasePanel()
    {
        if (PlayerPrefs.GetInt("SolarPanel") > 0)
        {
            int s = PlayerPrefs.GetInt("SolarPanel");
            s--;
            PlayerPrefs.SetInt("SolarPanel", s);
        }
    }
}
