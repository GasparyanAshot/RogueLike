using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPRegenItem : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			PlayerController player=collider.GetComponent<PlayerController>();
			if(player.MP+5<=player.MaxMP){
				player.MP+=5;
				Destroy (this.gameObject);
			}
			else if(player.MP<player.MaxMP){
				player.MP=player.MaxMP;
				Destroy (this.gameObject);
			}
		}
	}
}
