using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public Color randomColor;
    public Color enemyRandomColor;
    public Color[] colors;
    public GameObject[] pipes;
    public GameObject enemyCylinder,selectedEnviro;
    private void Awake() {
        RandomColor();
        InstantiatePipe();
    }
    void Update()
    {
        SetMeshColor();
        InstantiatePipe();
    }
    public void SetMeshColor(){
        GameObject[] enemyCylinder = GameObject.FindGameObjectsWithTag("Destroy");
        foreach (GameObject item in enemyCylinder){
            if(item.GetComponent<Renderer>().material.color != enemyRandomColor){
                item.GetComponent<Renderer>().material.color = enemyRandomColor;
            }
        }
        GameObject[] enviros = GameObject.FindGameObjectsWithTag("Enviro");
        foreach (GameObject item in enviros){
            if(item.transform.GetComponentInChildren<Renderer>().material.color != randomColor){
                item.transform.GetComponentInChildren<Renderer>().material.color = randomColor;
            }
        }
    }
    void RandomColor(){
        randomColor = colors[Random.Range(0,colors.Length)];
        enemyRandomColor = colors[Random.Range(0,colors.Length)];
        while(randomColor == enemyRandomColor){
            enemyRandomColor = colors[Random.Range(0,colors.Length)];   
        }
    }

    public void InstantiatePipe(){
        GameObject[] spawnedPipe = GameObject.FindGameObjectsWithTag("Cylinder");
        GameObject pipe = pipes[Random.Range(0,pipes.Length)];
        if(spawnedPipe.Length < 10){
            if(spawnedPipe.Length > 0){
                pipe.transform.localScale = new Vector3(1,Random.Range(3,5),1);
                GameObject instantPipe = Instantiate(pipe,new Vector3(0,YpointCalculate(spawnedPipe[spawnedPipe.Length-1],pipe.transform.GetChild(0).gameObject)
                 ,0),Quaternion.identity);
                Debug.Log(
                    instantPipe.GetComponentInChildren<MeshRenderer>().bounds.size.y  / selectedEnviro.GetComponentInChildren<MeshRenderer>().bounds.size.y
                    );
                
            }
            else if(spawnedPipe.Length == 0){
                Instantiate(pipe,new Vector3(0,-7,0),Quaternion.identity);
            }
        }
    }
    public float YpointCalculate(GameObject cylinder1, GameObject cylinder2){
        return cylinder1.GetComponent<MeshRenderer>().bounds.max.y+ cylinder2.transform.lossyScale.y;
    }
}
