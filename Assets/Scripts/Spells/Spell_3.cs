using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_3 : MonoBehaviour {

	private float AnimSpeed=8;
	public Spell spell;
	public GameObject Particle;
	private Transform ThisTransform;
	private int Damage=5;

	void Start(){
		ThisTransform = transform;
		spell = GetComponent<Spell>();
		Invoke ("Destroy",3);
	}

	void FixedUpdate () {
		ThisTransform.Rotate (Vector3.forward * AnimSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			if (collider.gameObject.GetComponent<Enemy> () != null) {
				collider.gameObject.GetComponent<Enemy> ().HP -= (Damage + spell.DamageUp) * (1 + spell.DamageUpPracentage / 100);
			} 
		}
		if (collider.gameObject.tag == "EnemyHitBox") {
			if (collider.gameObject.GetComponentInParent<Enemy> () != null) {
				collider.gameObject.GetComponentInParent<Enemy> ().HP -= (Damage + spell.DamageUp) * (1 + spell.DamageUpPracentage / 100);
			}
		}
	}

	void Destroy(){
		Destroy (gameObject);
	}
}
