using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenShop : MonoBehaviour {

	public void OpenTheShop()
    {
        
        SceneManager.LoadScene("Shop Scene");
    }

    public void OpenOutsideShop()
    {
        SceneManager.LoadScene(4);
    }
}
