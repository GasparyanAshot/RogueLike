using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Booll : MonoBehaviour {

	private Transform ThisTransform;

	public Enemy enemy;
	public AIDestinationSetter AITarget;
	public AILerp AI;
	GameObject Player;

	void Start () {
		ThisTransform = transform;
		Player = GameObject.FindGameObjectWithTag ("Player");
		AITarget.target = Player.transform;
		AI.canMove=true;
	}

	void Update () {
		if (Player.transform.position.x > ThisTransform.position.x) {
			ThisTransform.Rotate (Vector3.forward*-200*Time.deltaTime);
		}
		if (Player.transform.position.x <= ThisTransform.position.x) {
			ThisTransform.Rotate (Vector3.forward*200*Time.deltaTime);
		}

	}
}
