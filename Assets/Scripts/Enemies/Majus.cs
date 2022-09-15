using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Majus : MonoBehaviour {

	public Spell spell;
	public Enemy enemy;
	float StartPosY;
	bool AnimUp;
	public AIDestinationSetter AITarget;
	public AILerp AI;
	public float DistanceToMove;
	private Transform ThisTransform;

	void Start () {
		ThisTransform = transform;
		Invoke ("Fire", 2);
		StartPosY = ThisTransform.position.y;
	}

	void Update(){
			Anim ();
	}

	void Anim(){
			if (AnimUp) {
				if ((ThisTransform.position.y - StartPosY) < 0.24f) {
					ThisTransform.Translate (Vector2.up * 0.5f * Time.deltaTime);
				} else {
					AnimUp = false;
				}
			}
			else{
				if ((transform.position.y - StartPosY) >0f) {
					ThisTransform.Translate (Vector2.down * 0.5f * Time.deltaTime);
				} else {
					AnimUp = true;
				}

			}
	}

	void Fire () {
			Spell newspell1 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell1.Direction = Vector2.up;
			Spell newspell2 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell2.Direction = Vector2.down;
			Spell newspell3 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell3.Direction = Vector2.right;
			Spell newspell4 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell4.Direction = Vector2.left;
			Spell newspell5 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell5.Direction = new Vector2 (0.5f, 0.5f);
			Spell newspell6 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell6.Direction = new Vector2 (-0.5f, -0.5f);
			Spell newspell7 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell7.Direction = new Vector2 (-0.5f, 0.5f);
			Spell newspell8 = Instantiate (spell, ThisTransform.position, Quaternion.identity);
			newspell8.Direction = new Vector2 (0.5f, -0.5f);
		Invoke ("Fire", 2);

	}
}
