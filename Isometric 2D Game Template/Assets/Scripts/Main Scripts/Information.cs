using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour {

    public GameObject energyBar;
    public Button pot;
    public Button shop;
    private Image Panel;

	// Use this for initialization
	void Start () {
        gameObject.transform.GetChild(1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void openPanel()
    {
        gameObject.transform.GetChild(0).transform.GetComponent<Image>().enabled = false;
        Building_Movement.PANEL_ON = true;
        Outside.PANEL_ON = true;
        House.PANEL_ON = true;
        Water.PANEL_ON = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        energyBar.gameObject.SetActive(false);
        pot.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
        StartCoroutine(Wait2());

    }

    public void closePanel()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        energyBar.gameObject.SetActive(true);   
        pot.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameObject.transform.parent.transform.GetChild(0).tag == "Not Clicked")
        {
            gameObject.transform.parent.transform.GetChild(0).tag = "Clicked";
        }

        gameObject.transform.GetChild(0).transform.GetComponent<Image>().enabled = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);

        Building_Movement.PANEL_ON = false;
        Outside.PANEL_ON = false;
        House.PANEL_ON = false;
        Water.PANEL_ON = false;

        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        Debug.Log("close");
    }
}
