using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Map{
	public int x;
	public int z;

	public string effect;
	public GameObject occupied;
	
	public Map() {
		effect = " ";
		occupied = GameObject.Find("Null");
	}
}

public class MapController : MonoBehaviour {

	public int mapSizeX;
	public int mapSizeZ;
	public static int SSmapSizeX;
	public static int SSmapSizeZ;
	public static Map[,] map = new Map[10, 10];
	public int finishX;
	public int finishZ;
	
	// Use this for initialization
	void Start () {
		SSmapSizeX = mapSizeX;
		SSmapSizeZ = mapSizeZ;
		for(int i = 0; i<mapSizeX; i++){
			for(int j = 0; j<mapSizeZ; j++){
				map[i,j] = new Map();
				map[i,j].x = i;
				map[i,j].z = j;
			}
		}
		InitiateEffect();
		InstantiateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitiateEffect(){
		// win place
		map[finishX, finishZ].effect = "win";
		// // char place
		// map[this.transform.position.x, spawnZ].occupied = true;
		// // obs place
		// for(int i = 0; i< obsX.Length ; i++)
		// 	map[obsX[i], obsZ[i]].occupied = true;
		// // swc place
		// for(int i = 0; i< swcX.Length ; i++)
		// 	map[swcX[i], swcZ[i]].locked = true;
		// // key place
		// for(int i = 0; i< keyX.Length ; i++)
		// 	map[keyX[i], keyZ[i]].effect = "key";
	}

	void InstantiateMap(){
		// instantiate Boxnya
	}
}
