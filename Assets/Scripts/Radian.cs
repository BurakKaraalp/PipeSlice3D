using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Radian : MonoBehaviour
{
    public GameObject cube,cylinder;
    public float cubeCount;
    public float angle;
    public int yCount;
    
    private void Start() {
        cube = gameObject;
        float cirfer = 2*Mathf.PI*(cylinder.transform.localScale.z/2);
        cubeCount = Mathf.Round(cirfer/cube.transform.GetChild(0).GetComponent<Collider>().bounds.size.x);
        InstantiateCube();
    }
    public void InstantiateCube() {
        while(true){
            cylinder = GameObject.FindGameObjectWithTag("Ring").GetComponent<Enviro>().getTriggerObject();
            if(cylinder != null){
                break;
            }
        }
        float optimizedAngle = 360 / cubeCount;
        for (var i = 0; i < yCount; i++)
        {
            for (var z = 0; z <= cubeCount; z++)
        {
            GameObject cubeObject = Instantiate(cube,new Vector3(Mathf.Cos(angle*Mathf.Deg2Rad) * cylinder.transform.localScale.x/2
            ,cube.transform.position.y,
            Mathf.Sin(angle*Mathf.Deg2Rad)*cylinder.transform.localScale.z/2),
            Quaternion.identity);
            //obje leaf ise angle+90
            cubeObject.transform.Rotate(0f,-(cubeObject.transform.rotation.y+angle),0f);
            //Debug.Log("Angle: "+angle+"Position: " +Mathf.Cos(angle*Mathf.Rad2Deg)+" - " +  Mathf.Sin(angle*Mathf.Rad2Deg));
            angle = angle + optimizedAngle;
        }
        cube.transform.position = new Vector3(cube.transform.position.x
            ,cube.transform.position.y + cube.transform.localScale.y + 0.01f,
            cube.transform.position.z);
        }
        Destroy(cube);
    }
}
