using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Shield : MonoBehaviour {

	public Enemy enemy;
	public AIDestinationSetter AITarget;
	public AILerp AI;
	public Animator anim;
	public SpriteRenderer Sprite;
	private Transform ThisTransform;

	void Start () {
		AITarget.target = GameObject.FindGameObjectWithTag ("Player").transform;
		ThisTransform = transform;
	}
	
	void Update () {
		if (!AI.canMove) {
			AI.canMove=true;
		} else if(AI.canMove){
			AI.canMove = false;
		}
		if (AITarget.target.transform.position.x > ThisTransform.position.x && Sprite.flipX) {
			Sprite.flipX = false;
		}
		if (AITarget.target.transform.position.x < ThisTransform.position.x && !Sprite.flipX) {
			Sprite.flipX = true;
		}
		if (AITarget.target.transform.position.y > ThisTransform.position.y && !anim.GetBool("Back")) {
			anim.SetBool ("Back", true);
		}
		if (AITarget.target.transform.position.y < ThisTransform.position.y && anim.GetBool("Back")) {
			anim.SetBool ("Back", false);
		}

	}
}
