using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegenItem : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			PlayerController player=collider.GetComponent<PlayerController>();
			if(player.HP<player.MaxHP){
				player.HP++;
				Destroy (this.gameObject);
			}
		}
	}
}
