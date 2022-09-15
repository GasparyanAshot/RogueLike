using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int AllowedLvl;
	public GameObject AnimObj;

	public Enemy[] EnemiesLvl1;
	public Enemy[] EnemiesLvl2;
	public Enemy[] EnemiesLvl3;

	private Room room;

	public void StartSpawning(Room Room){
		Room.EnemiesInRoom++;
		room = Room;
		AnimObj.SetActive (true);

		Invoke ("Spawn", 1);
	}

	public void Spawn(){

		int LvlChance = Random.Range (0,100);
		int i;

		if (LvlChance <= 50) {
			i = 1;
		} else if (LvlChance <= 85 && AllowedLvl >= 2) {
			i = 2;
		} else if (AllowedLvl == 3) {
			i = 3;
		} else {
			i = 1;
		}

		if (i==1) {
			Enemy newenemy = Instantiate (EnemiesLvl1 [Random.Range (0, EnemiesLvl1.Length)], transform.position, Quaternion.identity);
			newenemy.room = room;
		}
		if (i==2) {
			Enemy newenemy = Instantiate (EnemiesLvl2 [Random.Range (0, EnemiesLvl2.Length-1)], transform.position, Quaternion.identity);
			newenemy.room = room;
		}
		if (i==3) {
			Enemy newenemy = Instantiate (EnemiesLvl3 [Random.Range (0, EnemiesLvl3.Length-1)], transform.position, Quaternion.identity);
			newenemy.room = room;
		}
		Destroy (gameObject);
	}
		
}
