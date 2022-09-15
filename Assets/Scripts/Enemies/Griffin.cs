using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Griffin : MonoBehaviour {

	public Enemy enemy;
	public AIDestinationSetter AITarget;
	public AILerp AI;
	bool IsFlying = true;
	public Animator anim;
	public Spell spell;
	bool Fliped;
	Transform ThisTransform;

	void Start(){
		AITarget.target = GameObject.FindGameObjectWithTag ("Player").transform;
		ThisTransform = transform;
		Fly ();
	}

	void Update () {
		if (IsFlying) {
			AI.canMove=true;
		} else {
			AI.canMove = false;
		}
		if (enemy.player.ThisTransform.position.x > ThisTransform.position.x && !Fliped) {
			ThisTransform.rotation = Quaternion.AngleAxis (180, new Vector2 (0, 1));
			Fliped = true;
		}
		if (enemy.player.ThisTransform.position.x < ThisTransform.transform.position.x && Fliped) {
			ThisTransform.rotation = Quaternion.AngleAxis (0, new Vector2 (0, 1));
			Fliped = false;
		}
	}

	void Fly(){
		anim.SetBool ("Fly", true);
		IsFlying = true;
		Invoke ("Cry", 7);
	}

	void Cry(){
		anim.SetBool ("Fly", false);
		IsFlying = false;
		Invoke ("Fire", 1.5f);
		Invoke ("Fly", 3);
	}

	void Fire(){
		Vector3 MountPos;

		if (Fliped) {
			MountPos = new Vector3 (1.5f, 1.5f, 0);
		} else {
			MountPos = new Vector3 (-1.5f, 1.5f, 0);
		}

		Spell newspell1 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell1.Direction = Vector2.up;
		Spell newspell2 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell2.Direction = Vector2.down;
		Spell newspell3 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell3.Direction = Vector2.right;
		Spell newspell4 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell4.Direction = Vector2.left;
		Spell newspell5 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell5.Direction = new Vector2 (0.5f, 0.5f);
		Spell newspell6 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell6.Direction = new Vector2 (-0.5f, -0.5f);
		Spell newspell7 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell7.Direction = new Vector2 (-0.5f, 0.5f);
		Spell newspell8 = Instantiate (spell, ThisTransform.position+MountPos, Quaternion.identity);
		newspell8.Direction = new Vector2 (0.5f, -0.5f);
	}
}
