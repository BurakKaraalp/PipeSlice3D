using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviro : MonoBehaviour
{
    public GameObject triggerObject, particle;
    public bool touchTrigger = false;
    private void OnTriggerEnter(Collider other) {
        triggerObject = other.gameObject;
        if(other.gameObject.tag == "Enviro" && touchTrigger){
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*60);
        }
        if(other.gameObject.tag == "Destroy"){
            if(particle != null){
            Instantiate(particle,other.gameObject.transform.position,Quaternion.Euler(-90,0,0));
            }
            Destroy(GameObject.FindGameObjectWithTag("Ring"));
            Destroy(GameObject.FindGameObjectWithTag("RingScript"));
        }
    }
    public GameObject getTriggerObject(){
        return triggerObject;
    }
    public void SetTouchTrigger(bool touchTrigger_){
        touchTrigger = touchTrigger_;
    }
}
