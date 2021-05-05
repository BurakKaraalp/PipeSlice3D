using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDestroy : MonoBehaviour
{
    public GameObject particle;
    public static RingDestroy instance;
    public void Start() {
        instance = this;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Destroy" && GameObject.FindGameObjectWithTag("Ring").GetComponent<Enviro>().getTouchTrigger()){
           DestroyRing(other);
           Debug.Log("Test");
        }
        if(other.gameObject.tag == "ExternalDestroyer" && !GameObject.FindGameObjectWithTag("Ring").GetComponent<Enviro>().getTouchTrigger()){
           DestroyRing(other);
        }
    }
    public void DestroyRing(Collider other){
         Instantiate(particle,other.gameObject.transform.position,Quaternion.Euler(-90,0,0));
        Destroy(GameObject.FindGameObjectWithTag("Ring"));
        Destroy(GameObject.FindGameObjectWithTag("RingScript"));
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().speed = 0;
    }
}
