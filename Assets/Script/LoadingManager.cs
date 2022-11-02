using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingManager : MonoBehaviour
{
    public Slider progressbar;
    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Stage01");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            if (progressbar.value >= 1f)
            {
                operation.allowSceneActivation = true;
            }
        }
        
    }
}
