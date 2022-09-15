using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

	public PlayerController Controller;

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			if (Controller.Shields > 0 && Random.Range(0,100)<=Controller.ShieldChance) {
				Controller.Shields--;
			} else {
				Controller.HP--;
			}
		}
	}
}
