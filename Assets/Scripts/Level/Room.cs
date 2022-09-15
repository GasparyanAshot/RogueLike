using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

	public GameObject DoorR;
	public GameObject DoorL;
	public GameObject DoorU;
	public GameObject DoorD;

	public EnemySpawner SpawnerPrefab;
	public Chest ChestPrefab;

	public Transform[] Spawnpoints;

	public int EnemiesInRoom=0;

	public bool CommonRoom;
	public bool ChestRoom;


	public void StartSpawning(){
		if (CommonRoom) {
			for (int i = 0; i < Spawnpoints.Length; i++) {
				if (Random.Range (0, 100) < 75) {
					EnemySpawner spawner = Instantiate (SpawnerPrefab, Spawnpoints [i].transform);
					spawner.StartSpawning (this);
				}
			}
		}
		if (ChestRoom) {
			for (int i = 0; i < Spawnpoints.Length; i++) {
				Instantiate (ChestPrefab, Spawnpoints [i].transform.position,Quaternion.identity,this.gameObject.transform);
			}
		}
	}	

}
