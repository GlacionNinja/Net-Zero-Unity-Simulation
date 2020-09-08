using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenBuildingsScene : MonoBehaviour {

    public void openBuildingScene()
    {
        SceneManager.LoadScene("Building Scene");
    }
}