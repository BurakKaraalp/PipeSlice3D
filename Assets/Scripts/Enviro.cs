using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviro : MonoBehaviour
{
    public static Enviro instance;
    public GameObject triggerObject, particle;
    
    public bool touchTrigger;
    public void Start() {
        instance = this;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Cylinder"){
            triggerObject = other.gameObject;
        }
        if(other.gameObject.tag == "Enviro" && touchTrigger){
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*60);
        }
    }
    public GameObject getTriggerObject(){
        return triggerObject;
    }
    public void setTouchTrigger(bool touchTrigger_){
        touchTrigger = touchTrigger_;
    }
    public bool getTouchTrigger(){
        return touchTrigger;
    }
}
