using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InfectedWorm : MonoBehaviour {

	public Enemy enemy;
	public AIDestinationSetter AITarget;
	public AILerp AI;

	void Start(){
		AITarget.target = GameObject.FindGameObjectWithTag ("Player").transform;
		AI.canMove=true;
	}
		
}
