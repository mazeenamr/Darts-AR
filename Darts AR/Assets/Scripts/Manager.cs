using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject arrow;
    public GameObject Camera;
    float offset = 0.4f;
    bool lastArrow = false;
    public float Power= 0;
    private List<GameObject> Arrows;
    public List<GameObject> ArrowsList;
    public int ArrowPoolSize= 6 ;
    public int arrowShotNumber = 0;
    bool previousWasTouching = false;
    bool isTouching;
    public GameObject endGui;
    //public GameObject _Score;
    public ScoreScript score;
    private void Start()
    {
        IntializeArrows();
    }
    void IntializeArrows()
    {
        Arrows = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < ArrowPoolSize; i++)
        {
            tmp = Instantiate(arrow);
            tmp.SetActive(false);
            Arrows.Add(tmp);
            setArrowLocation(Arrows[i]);
        }
        Arrows[arrowShotNumber].SetActive(true);

    }
    public void ResetArrows()
    {
        arrowShotNumber = 0;
        for (int i = 0; i < ArrowPoolSize; i++)
        {
            Arrows[i].GetComponent<MeshCollider>().enabled = true;
            Arrows[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Arrows[i].GetComponent<Rigidbody>().isKinematic = false;
            Arrows[i].GetComponent<Rigidbody>().useGravity = false;
            Arrows[i].SetActive(false);
            setArrowLocation(Arrows[i]);
            ArrowsList[i].SetActive(true);
        }
        Arrows[arrowShotNumber].SetActive(true);
        endGui.SetActive(false);
        //_Score.SetActive(true);
        score.ScoreCounter = 0;
        lastArrow = false;
    }

    void Update()
    {
        if(!lastArrow) setArrowLocation(Arrows[arrowShotNumber]);
        isTouching = Input.touchCount > 0;
        if (isTouching && !previousWasTouching) ShotArrow();
        previousWasTouching = isTouching;
    }

    public void ShotArrow()
    {
        Debug.Log("Arrow Number  : "+arrowShotNumber);
        if(arrowShotNumber >= ArrowPoolSize)
        {
            arrowShotNumber = 0;
            Debug.Log("finish");
        }
        else
        {
            ArrowsList[arrowShotNumber].SetActive(false);
            Rigidbody rg = Arrows[arrowShotNumber].GetComponent<Rigidbody>();
            rg.useGravity = true;
            rg.isKinematic = false;
            rg.AddForce((Camera.transform.forward + Camera.transform.up) * Power);
            Debug.Log("Force :  "+ (Camera.transform.forward + Camera.transform.up) * Power);
            arrowShotNumber++;
            if (arrowShotNumber == 6)
            {
                StartCoroutine("EndMenu");
                lastArrow = true;
                return;
            }
            Arrows[arrowShotNumber].SetActive(true);
            previousWasTouching = true;
            //SpawnArrow();
        }
    }
    IEnumerator EndMenu()
    {
        yield return new WaitForSeconds(1);
        //_Score.SetActive(false);
        endGui.SetActive(true);

    }

    public void setArrowLocation(GameObject Arrow)
    {
        Arrow.transform.position = Camera.transform.position + Camera.transform.forward * offset;
        Arrow.transform.rotation = new Quaternion(0.0f, Camera.transform.rotation.y, 0.0f, Camera.transform.rotation.w);
        Arrow.transform.Rotate(-105f, 0, 0);
    }
    
}
