using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedSpell : MonoBehaviour {

	public float Speed;
	public Spell spell;
	public GameObject Particle;
	private Transform ThisTransform;

	void Start(){
		ThisTransform = transform;
		spell = GetComponent<Spell>();
	}

	void FixedUpdate () {
		ThisTransform.Translate (spell.Direction * Speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Character") {
			collider.gameObject.GetComponentInParent<PlayerController> ().HP--;
			Instantiate (Particle,transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
		if (collider.gameObject.layer == 9) {
			Instantiate (Particle,transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
