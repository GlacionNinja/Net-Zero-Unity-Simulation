using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour {

    //add a new Variable + duplicate spawnWindmill + removeWindmill methods and tweak them with the new variables
    private int maxWindTrees = 5;
    public Text error;

	    public void goToHomeScene()
    {
        SceneManager.LoadScene("Game Scene");
       
    }

    public void goOutside()
    {
        SceneManager.LoadScene("Outside Scene");
    }

    public void spawnWindmill()
    {
        if (PlayerPrefs.GetInt("WindTree") < maxWindTrees)
        {
            int windmill = PlayerPrefs.GetInt("WindTree");
            windmill++;
            PlayerPrefs.SetInt("WindTree", windmill);

            PlayerPrefs.SetInt("NewWindTree", 1);
            SceneManager.LoadScene("Outside Scene");
        }        


        else
        {
            error.text = "Cannot spawn in more wind turbines. Max limit reached.";
            StartCoroutine(Fade());
        }
    }

    public void removeWindmill()
    {
        if (PlayerPrefs.GetInt("WindTree") > 0)
        {
            int windmill = PlayerPrefs.GetInt("WindTree");
            windmill--;
            PlayerPrefs.SetInt("WindTree", windmill);
            SceneManager.LoadScene("Outside Scene");
        }

        else
        {
            error.text = "Cannot remove any wind turbines as zero exist on map.";
            StartCoroutine(Fade());
        }
    }

    private IEnumerator Fade()
    {
        error.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.6f);
        error.gameObject.SetActive(false);
    }
}