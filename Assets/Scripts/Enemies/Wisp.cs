using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour {

	GameObject Player;
	public Enemy enemy;
	Vector2 Point;
	private Transform ThisTransform;
	private Animator anim;

	void Start () {
		ThisTransform = transform;
		Player = GameObject.FindGameObjectWithTag ("Player");
		anim = gameObject.GetComponent<Animator> ();
		Invoke ("GetReadyToTp",4);
	}

	private void TpToPlayer(){
		anim.SetBool ("GetReady", false);
		ThisTransform.position = Player.transform.position;
		Invoke ("GetReadyToTp",4);
	}

	private void GetReadyToTp(){
		anim.SetBool ("GetReady", true);
		Invoke ("TpToPlayer",1);
	}

	private void Update(){
		ThisTransform.Rotate (Vector3.forward*15*Time.deltaTime);
	}
}
