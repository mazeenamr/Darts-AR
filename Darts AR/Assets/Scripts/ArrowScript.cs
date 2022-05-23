using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrowScript : MonoBehaviour
{
    Rigidbody rg;
    private void Start()
    {
      
        rg = this.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("board"))
        {
            this.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            rg.isKinematic = true;
            Debug.Log("Collides with  : " +other.gameObject.name);
        }
        if (other.CompareTag("woodBoard"))
        {
            this.GetComponent<AudioSource>().Play();
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            rg.isKinematic = true;
            Debug.Log("Collides with  : " +other.gameObject.name);
        }

    }
}
