using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy_System : MonoBehaviour {

    private float maxEnergy;
    private float currentEnergy;

    private float maxEnergy2;
    private float currentEnergy2;


    public Image Energy_Bar;
    public Image Energy_Bar2;

    public Text change;

    // Use this for initialization
    void Start () {
        maxEnergy = 100f;
        //currentEnergy = 77f;     

        maxEnergy2 = 100f;
        //currentEnergy2 = 77f;
	}
	
	// Update is called once per frame
	void Update () {
        //Energy_Bar.fillAmount = currentEnergy / maxEnergy;
        //Energy_Bar2.fillAmount = currentEnergy2 / maxEnergy2;

        if (Energy_Bar.fillAmount >= 0 && Energy_Bar.fillAmount < 0.25)
        {
            Energy_Bar.transform.GetComponent<Image>().color = Color.red;
        }

        if (Energy_Bar.fillAmount >= 0.25 && Energy_Bar.fillAmount < 0.42)
        {
            Energy_Bar.transform.GetComponent<Image>().color = new Color32(255, 110, 0, 255);
        }

        if (Energy_Bar.fillAmount >= 0.42 && Energy_Bar.fillAmount < 0.5)
        {
            Energy_Bar.transform.GetComponent<Image>().color = Color.yellow;
        }

        if (Energy_Bar.fillAmount >= 0.5 && Energy_Bar.fillAmount < 0.55)
        {
            Energy_Bar.transform.GetComponent<Image>().color = new Color32(176, 255, 0, 255);
        }

        if (Energy_Bar.fillAmount >= 0.55 && Energy_Bar.fillAmount < 0.65)
        {
            Energy_Bar.transform.GetComponent<Image>().color = new Color32(108, 255, 0, 255);
        }

        if (Energy_Bar.fillAmount >= 0.65 && Energy_Bar.fillAmount < 0.75)
        {
            Energy_Bar.transform.GetComponent<Image>().color = new Color32(54, 255, 0, 255);
        }

        if (Energy_Bar.fillAmount >= 0.75 && Energy_Bar.fillAmount <= 1.00)
        {
            Energy_Bar.transform.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }

        if (Energy_Bar2.fillAmount >= 0 && Energy_Bar2.fillAmount < 0.25)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = Color.red;
        }

        if (Energy_Bar2.fillAmount >= 0.25 && Energy_Bar2.fillAmount < 0.42)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = new Color32(255, 110, 0, 255);
        }

        if (Energy_Bar2.fillAmount >= 0.42 && Energy_Bar2.fillAmount < 0.5)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = Color.yellow;
        }

        if (Energy_Bar2.fillAmount >= 0.5 && Energy_Bar2.fillAmount < 0.55)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = new Color32(176, 255, 0, 255);
        }

        if (Energy_Bar2.fillAmount >= 0.55 && Energy_Bar2.fillAmount < 0.65)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = new Color32(108, 255, 0, 255);
        }

        if (Energy_Bar2.fillAmount >= 0.65 && Energy_Bar2.fillAmount < 0.75)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = new Color32(54, 255, 0, 255);
        }

        if (Energy_Bar2.fillAmount >= 0.75 && Energy_Bar2.fillAmount <= 1.00)
        {
            Energy_Bar2.transform.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
        }
    }
}
