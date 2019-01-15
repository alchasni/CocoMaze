using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsController : MonoBehaviour {

	public int x,z;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MapController.map[x,z].occupied = gameObject;
		transform.position = new Vector3(x,transform.position.y,z);
	}
}
