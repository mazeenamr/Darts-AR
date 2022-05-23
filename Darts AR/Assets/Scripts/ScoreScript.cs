using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public int ScoreCounter=0;
    //public TMP_Text _Score;
    public TMP_Text FinalScore;
    public animateText text;

    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter += 5;
        CalcScore(ScoreCounter);
        StartCoroutine("FadingText");
    }
    IEnumerator FadingText()
    {
        text.showUi();
        yield return new WaitForSeconds(1);
        text.hideUi();
    }
    void CalcScore(int score) {
        //_Score.text = "Score: " + score;
        FinalScore.text = "+" + score;
    }
}
