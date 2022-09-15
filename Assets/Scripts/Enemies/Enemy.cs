using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int HP;
	public Particle DeadParticle;
	public GameObject HPRegenItem;
	public GameObject MPRegenItem;
	public PlayerController player;
	public Room room;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerController>();
	}

	void Update () {
		if(HP<=0){
			room.EnemiesInRoom--;
			Particle NewParticle = Instantiate (DeadParticle,transform.position,Quaternion.identity,room.transform);
			int i = Random.Range (0, 100);
			if (i< 20) {
				Instantiate (HPRegenItem, transform.position, Quaternion.identity,room.transform);
			}
			else if(i<70){
				Instantiate (MPRegenItem, transform.position, Quaternion.identity,room.transform);
			}
			Destroy (gameObject);
		}
	}
		
}
