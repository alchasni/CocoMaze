using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsMover : MonoBehaviour {
	public int x;
	public int z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
    {
		int obsX = transform.parent.gameObject.GetComponent<obsController>().x;
		int obsZ = transform.parent.gameObject.GetComponent<obsController>().z;
		int newX = obsX + x;
		int newZ = obsZ + z;

		if(newX < 0 || newX > MapController.SSmapSizeX){
			return;
		}
		else if(newZ < 0 || newZ > MapController.SSmapSizeZ){
			return;
		}
		else if(MapController.map[obsX+x,obsZ+z].occupied == GameObject.Find("Null")){
			MapController.map[transform.parent.gameObject.GetComponent<obsController>().x,transform.parent.gameObject.GetComponent<obsController>().z].occupied = GameObject.Find("Null");
			
			transform.parent.gameObject.GetComponent<obsController>().x += x;
			transform.parent.gameObject.GetComponent<obsController>().z += z;
			
			gameController.currentStep++;
			// MapController.map[transform.parent.gameObject.GetComponent<obsController>().x,transform.parent.gameObject.GetComponent<obsController>().z].occupied = true;
		}
		else{
			return;
		}

    }
}
