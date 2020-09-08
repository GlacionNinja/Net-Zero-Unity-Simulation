using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScene : MonoBehaviour {

    public static float x;
    
	// Use this for initialization
	void Start () {
        x = 0;
	}
	
	// Update is called once per frame
	void Update () { 

	}

    public void SceneSwap()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(2);
            return;
        }
    }
}
