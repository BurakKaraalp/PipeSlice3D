using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ring : MonoBehaviour
{
	//1unit cylinder 0.18,-0.35,0.05
	public Transform rayCastStart;
	public GameObject ring,cylinder,colTrigger;
	public Vector3 offset;
	Enviro enviro;
	Vector3 defaultScale = new Vector3(2.40f,2.40f,1.63f);
	private void Start() {
		ring = GameObject.FindGameObjectWithTag("Ring");
		enviro = colTrigger.GetComponent<Enviro>();
	}
	public void Update() {
		RingClick();
	}
	public void RingClick(){
		if(Input.touchCount > 0){
			cylinder = enviro.getTriggerObject();
			ring.GetComponent<Enviro>().SetTouchTrigger(true);
			if(cylinder.tag != "Ring" && ring.transform.localScale.y >= cylinder.transform.localScale.z){
				ring.transform.localScale = Vector3.Lerp(ring.transform.localScale, new Vector3(cylinder.transform.localScale.x + offset.x,
				cylinder.transform.localScale.z + offset.y,
				ring.transform.localScale.z), 0.5f);
			}	
		}
		if(Input.touchCount == 0){
			cylinder = enviro.getTriggerObject();
			ring.GetComponent<Enviro>().SetTouchTrigger(false);
			ring.transform.localScale = Vector3.Lerp(ring.transform.localScale,defaultScale,0.5f);
		}
	}
}
