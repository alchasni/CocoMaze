using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

	public GameObject[] obstacle;
	public int[] objX;
	public int[] objZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other){
		for(int i =0; i< obstacle.Length; i++){
			if(MapController.map[objX[i],objZ[i]].occupied == GameObject.Find("Null")){
				obstacle[i].SetActive(! obstacle[i].gameObject.activeSelf);
				MapController.map[objX[i],objZ[i]].occupied = obstacle[i];
			}
			else {
				obstacle[i].SetActive(! obstacle[i].gameObject.activeSelf);
				MapController.map[objX[i],objZ[i]].occupied = GameObject.Find("Null");
			}
		}
	}

}
