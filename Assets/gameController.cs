using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	public static string status;
	public static int rotateDirection;

	public int keyGoal;
	public static int currentKey;
	public int maxStep;
	public static int currentStep;

	bool cameraRotating;
	Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
		status = "play";
		rotateDirection = 0;
		currentKey = 0;
		currentStep = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(status == "win")
			Win();
		if(status == "lose")
			Lose();

		if(keyGoal == currentKey && status == "play")
			status = "complete";
		if(maxStep == currentStep && status == "play")
			status = "lose";

		if(cameraRotating){
			Vector3 normalizeDirection = (cameraPosition - transform.position).normalized;
			transform.position += normalizeDirection * 7 * Time.deltaTime;
			
			if(Vector3.Distance(transform.position, cameraPosition) <= 0.05f){
				transform.position = cameraPosition;
				cameraRotating = false;
			}
		}
		Vector3 center = new Vector3((MapController.SSmapSizeX-1)/2f, 0, (MapController.SSmapSizeZ-1)/2);
		transform.LookAt(center);
	}
	void Win(){
		//win
		print("you win");
		status = "end";
	}
	void Lose(){
		//lose
		print("you Lose");
		status = "end";
	}

	public void rotate(int dir){
		if(cameraRotating)
			return;
		else
			cameraRotating = true;

		rotateDirection += dir;
		if(rotateDirection > 3){
			rotateDirection = 0;
		}
		if(rotateDirection < 0){
			rotateDirection = 3;
		}
		if(rotateDirection == 1)
			cameraPosition = new Vector3 (5f, 5f, -2f);
		if(rotateDirection == 2)
			cameraPosition = new Vector3 (5f, 5f, 5f);
		if(rotateDirection == 3)
			cameraPosition = new Vector3 (-2f, 5f, 5f);
		if(rotateDirection == 0)
			cameraPosition = new Vector3 (-2f, 5f, -2f);
	}
}
