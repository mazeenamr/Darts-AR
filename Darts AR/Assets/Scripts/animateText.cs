using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animateText : MonoBehaviour
{
    public CanvasGroup UI_Text;

    bool fadeIn = false;
    bool fadeOut = false;

    public void showUi()
    {
        fadeIn = true;
        fadeOut = false;

    }
    public void hideUi()
    {
        fadeOut= true;
        fadeIn = false;

    }
    private void Update()
    {
        if (fadeIn)
        {
            if (UI_Text.alpha < 1)
            {
                UI_Text.alpha += Time.deltaTime *4;
                if(UI_Text.alpha >= 1)
                {
                    fadeIn = false;

                }
            }
        } 
        if (fadeOut)
        {
            if (UI_Text.alpha >=0)
            {
                UI_Text.alpha -= Time.deltaTime*4;
                if(UI_Text.alpha == 0)
                {
                    fadeOut = false;

                }
            }
        }
    }

    public void GoToMainMenu()
    {
        StartCoroutine("ReturnToMainMenu");
    }
    IEnumerator ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        yield return null;
        
    }
}
