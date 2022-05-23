using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject ButttonsGroup;
    public Slider slider;
    public void PlayGame()
    {
        Debug.Log("Pressed");
        ButttonsGroup.SetActive(false);
        StartCoroutine("PlayGameAsync");
    }
    IEnumerator PlayGameAsync()
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            //Debug.Log(operation.progress);
            yield return null;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
