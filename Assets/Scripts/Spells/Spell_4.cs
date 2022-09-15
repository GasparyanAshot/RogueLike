using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_4 : MonoBehaviour {

	public Spell spell;
	private Transform ThisTransform;
	private int Damage=6;

	void Start(){
		ThisTransform = transform;
		spell = GetComponent<Spell>();
		ThisTransform.SetParent (spell.Player.gameObject.transform);
		Invoke ("Destroy", 4.5f);
	}

	void OnTriggerStay2D (Collider2D collider) {
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
		if (collider.gameObject.tag == "EnemyMagic") {
			Destroy (collider.gameObject);
		}
	}

	private void Destroy(){
		Destroy (gameObject);
	}
}
