using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Script : MonoBehaviour
{

    AsyncOperation Ao;
    public Image ProgressBar;
    public Text ProgressPercentage;
    public Text HintText;
    int RandomNumber;

    void Start()
    {
        StartCoroutine(LoadLevelWithRealProgress());
        RandomNumber = Random.Range(1, 10);
        Debug.Log(RandomNumber);
        if (RandomNumber == 1)
            HintText.text = "Hint 1";        if (RandomNumber == 2)
            HintText.text = "Hint 2";
        if (RandomNumber == 3)
            HintText.text = "Hint 3";
        if (RandomNumber == 4)
            HintText.text = "Hint 4";
        if (RandomNumber == 5)
            HintText.text = "Hint 5";
        if (RandomNumber == 6)
            HintText.text = "Hint 6";
        if (RandomNumber == 7)
            HintText.text = "Hint 7";
        if (RandomNumber == 8)
            HintText.text = "Hint 8";
        if (RandomNumber == 9)
            HintText.text = "Hint 9";
        if (RandomNumber == 10)
            HintText.text = "Hint 10";
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1);
        Ao = SceneManager.LoadSceneAsync("Game Scene");
        while (Ao.progress <= 1)
        {
            if (Ao.progress != 1)
            {
                ProgressBar.GetComponent<Image>().fillAmount = Ao.progress;
                ProgressPercentage.text = Mathf.FloorToInt(Ao.progress * 100).ToString() + "%";
                Ao.allowSceneActivation = false;  
                       
                if (Ao.progress == 0.9f)
                {
                    ProgressBar.GetComponent<Image>().fillAmount = 1;
                    ProgressPercentage.text = "100%";
                    yield return new WaitForSeconds(0.5f);
                    Ao.allowSceneActivation = true;
                }
            }       

            yield return null;
        }
    }
}