using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	public int x;
	public int z;
	public string status;
	public string movePattern; // kanan / kiri / else
	public int[] hadap;
	public float delay;
	public float moveSpeed;
	public float turnSpeed;
	public bool player;
	
	float turnBy;
	float turnLeft;

	private GameObject NULL;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(status == "move"){
			Move();
		}
		else if(status == "idle"){
			StartCoroutine(Delay(delay));
			status = "try";
		}
		else if(status == "turn"){
			Turn();
		}
	}

	void MoveAttemp(){
		int toX = hadap[0];
		int toZ = hadap[1];

		if(toX == 0 && toZ == 1)
			transform.rotation = Quaternion.Euler(0,0,0);
		else if(toX == 0 && toZ == -1)
			transform.rotation = Quaternion.Euler(0,180,0);
		else if(toX == 1 && toZ == 0)
			transform.rotation = Quaternion.Euler(0,90,0);
		else if(toX == -1 && toZ == 0)
			transform.rotation = Quaternion.Euler(0,-90,0);
		if(x+toX < 0 || x+toX >= MapController.SSmapSizeX)
			TurnAttemp();
		else if(z+toZ < 0 || z+toZ >= MapController.SSmapSizeZ)
			TurnAttemp();
		else if(MapController.map[x+toX,z+toZ].occupied == GameObject.Find("Null"))
			status = "move";
		else if((player && MapController.map[x+toX,z+toZ].occupied.tag == "Enemy") || (!player && MapController.map[x+toX,z+toZ].occupied.tag == "Player")) {
			status = "move";
		}
		else
			TurnAttemp();
		
	}

	void Move(){
		int toX = hadap[0];
		int toZ = hadap[1];
		Vector3 targetPoint = new Vector3 (x+toX, 1f, z+toZ);
		Vector3 normalizeDirection = (targetPoint - transform.position).normalized;
		transform.position += normalizeDirection * moveSpeed * Time.deltaTime;
		
		MapController.map[x+toX,z+toZ].occupied = this.gameObject;
		if(Vector3.Distance(transform.position, targetPoint) <= 0.01f){
			transform.position = targetPoint;
			status = "idle";
			MapController.map[x,z].occupied = GameObject.Find("Null");
			x += toX;
			z += toZ;
			CheckEffect(x,z);
		}
	}

	void TurnAttemp(){
		turnBy = 90;
		if(hadap[0] == 0){
			if(movePattern == "kiri"){
				hadap[0] = hadap[1] * -1;
				hadap[1] = 0;
			}
			else if(movePattern == "kanan"){
				hadap[0] = hadap[1];
				hadap[1] = 0;
			}
			else{
				hadap[0] = 0;
				hadap[1] = hadap[1] * -1;
				turnBy = 180;
			}
		}
		else if(hadap[1] == 0){
			if(movePattern == "kiri"){
				hadap[1] = hadap[0];
				hadap[0] = 0;
			}
			else if(movePattern == "kanan"){
				hadap[1] = hadap[0] * -1;
				hadap[0] = 0;
			}
			else{
				hadap[1] = 0;
				hadap[0] = hadap[0] * -1;
				turnBy = 180;
			}
		}
		turnLeft = turnBy;
		status = "turn";
	}

	void Turn(){
		float theTime = Time.deltaTime * turnSpeed * 100f;
		if(movePattern == "kanan")
			transform.Rotate(Vector3.up * theTime);
		else
			transform.Rotate(Vector3.down * theTime);
		turnLeft -= theTime;
		if(turnLeft <= 0)
			status = "idle";
	}

	void OnTriggerEnter(Collider other){
		if (player) {
			if(other.CompareTag("Key"))
				Destroy(other.gameObject);
			if(other.CompareTag("Enemy")) {
				gameController.status="lose";
			}
		}
	}

	void CheckEffect(int x, int z){
		if(MapController.map[x,z].effect == "win"){
			if(gameController.status == "complete")
				gameController.status = "win";
		}
		else if(MapController.map[x,z].effect == "key"){
			gameController.currentKey++;
			MapController.map[x,z].effect = " ";
		}
	}

	IEnumerator Delay(float time){

		// process pre-yield
		yield return new WaitForSeconds( time );
		// process post-yield
		MoveAttemp();
	}
}
