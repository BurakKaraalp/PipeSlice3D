using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public Color randomColor;
    public int spawnedSet;
    float yPoint = 0;
    public GameObject[] sets;
    private void Awake() {
        RandomColor();
        SetMeshColor();
        InstantiateSet();
    }
    void Update()
    {
        InstantiateSet_();
    }
    public void SetMeshColor(){
        GameObject[] enemyCylinder = GameObject.FindGameObjectsWithTag("EnemyCylinder");
        foreach (GameObject item in enemyCylinder){
            item.GetComponent<Renderer>().material.color = randomColor;
        }
        GameObject[] enviros = GameObject.FindGameObjectsWithTag("Enviro");
        foreach (GameObject item in enviros){
            item.transform.GetComponentInChildren<Renderer>().material.color = randomColor;
        }
    }
    void RandomColor(){
        randomColor = UnityEngine.Random.ColorHSV();
    }
    public void InstantiateSet(){
        if(spawnedSet == 0){
            Instantiate(sets[Random.Range(0,sets.Length)],new Vector3(0,-13,0),Quaternion.identity);
            spawnedSet++;
        }
    }
    public void InstantiateSet_(){
        GameObject[] endPoints = GameObject.FindGameObjectsWithTag("EndPoint");
        if(endPoints.Length <= 2){
             for(int i = 0; i < endPoints.Length;i++){
                 Debug.Log(endPoints[i].transform.position.y );
                    if(endPoints[i].transform.position.y > yPoint){
                        yPoint = endPoints[i].transform.position.y; 
                }
                Instantiate(sets[Random.Range(0,sets.Length)],new Vector3(0,yPoint,0),Quaternion.identity);
                yPoint = 0;
            }
        }
    }
}
