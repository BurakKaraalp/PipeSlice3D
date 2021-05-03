using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fdestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.name.Contains("Cube")){
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else if(other.gameObject.transform.name == "EndPoint"){
            Destroy(other.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
        Destroy(other.gameObject);
    }
}
