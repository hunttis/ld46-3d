using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToStart : MonoBehaviour
{
    public GameObject titleText;
    public GameObject instructionsText;
    public GameObject loadingText;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Start game!");
            titleText.SetActive(false);
            instructionsText.SetActive(false);
            loadingText.SetActive(true);

            StartCoroutine(LoadGameScene());
        }
            
    }

    private IEnumerator LoadGameScene()
    {
        var asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
