using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_0 : MonoBehaviour {

	public float Speed;
	public Spell spell;
	public GameObject Particle;
	private Transform ThisTransform;
	private int Damage=1;

	void Start(){
		ThisTransform = transform;
		spell = GetComponent<Spell>();
		Speed += spell.SpeedUp;
	}

	void FixedUpdate () {
		ThisTransform = transform;
		ThisTransform.Translate (spell.Direction * Speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			if (collider.gameObject.GetComponent<Enemy> () != null) {
				collider.gameObject.GetComponent<Enemy> ().HP -= (Damage + spell.DamageUp) * (1 + spell.DamageUpPracentage / 100);
			} 

			Instantiate (Particle,new Vector3(ThisTransform.position.x,ThisTransform.position.y,-9f),Quaternion.identity,spell.Player.Generator.CurrentRoom.transform);
			Destroy (gameObject);
		}
		if (collider.gameObject.tag == "EnemyHitBox") {
			if (collider.gameObject.GetComponentInParent<Enemy> () != null) {
				collider.gameObject.GetComponentInParent<Enemy> ().HP -= (Damage + spell.DamageUp) * (1 + spell.DamageUpPracentage / 100);
			}

			Instantiate (Particle,new Vector3(ThisTransform.position.x,ThisTransform.position.y,-9f),Quaternion.identity,spell.Player.Generator.CurrentRoom.transform);
			Destroy (gameObject);
		}
		if (collider.gameObject.layer == 9) {
			Instantiate (Particle,new Vector3(ThisTransform.position.x,ThisTransform.position.y,-9f),Quaternion.identity,spell.Player.Generator.CurrentRoom.transform);
			Destroy (gameObject);
		}
	}
}
