using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excalibur : MonoBehaviour {

	GameObject Player;
	public Enemy enemy;
	public float Speed;
	Vector2 Point;
	bool IsAttacking;
	private Transform ThisTransform;

	void Start () {
		ThisTransform = transform;
		Player = GameObject.FindGameObjectWithTag ("Player");
		Invoke ("TurnToPlayer",1);
	}
	

	void FixedUpdate () {
		if(IsAttacking){
			if (Mathf.Sqrt(((Point.x-transform.position.x)*(Point.x-transform.position.x))+((Point.y-transform.position.y)*(Point.y-transform.position.y)))>1f) {
			ThisTransform.Translate (Vector2.up * Speed * Time.deltaTime);
		} else {
			Invoke ("TurnToPlayer",1);
			IsAttacking = false;
		}
		}
	}

	void TurnToPlayer(){
		Point = new Vector2(Player.transform.position.x,Player.transform.position.y);
		ThisTransform.up = Player.transform.position - ThisTransform.position;
		IsAttacking = true;
	}
}
