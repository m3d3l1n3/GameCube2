using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    public Slider slider;
    //for the slide to move accordingly to loading
    public void StartGame()
    {
        StartCoroutine(AsynchronousLoad("SampleScene"));
    }
    IEnumerator AsynchronousLoad(string scene)
    {
        AsyncOperation operationAsync = SceneManager.LoadSceneAsync(scene,LoadSceneMode.Single);
        while (!operationAsync.isDone)
        {
            float progress = Mathf.Clamp01(operationAsync.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");
            slider.value = progress; //makes the slider show the progress
            yield return null; 
        }
    }
}
