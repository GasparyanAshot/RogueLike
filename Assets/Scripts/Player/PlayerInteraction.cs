using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerInteraction : MonoBehaviour {

	public PlayerController Controller;
	public LevelGenerator_2 Generator_2;
	private Transform ThisTransform;
	public Inventory inventory;


	void Start () {
		ThisTransform = transform;
		AstarData data = AstarPath.active.data;
	}
	



	void OnTriggerStay2D (Collider2D collider) {

		if (collider.gameObject.tag == "Chest" && Controller.InteractionButtonPressed) {
			if(!collider.gameObject.GetComponent<Chest>().IsOpen){
				collider.gameObject.GetComponent<Chest> ().Open (Generator_2.CurrentRoom);
			}
		}

		if (collider.gameObject.tag == "PassiveItem" && Controller.InteractionButtonPressed) {
			if (inventory.GetNewItem (collider.gameObject.GetComponent<PassiveItem> ())) {
				Destroy (collider.gameObject);
			}
		}
		if (collider.gameObject.tag == "SpellItem" && Controller.InteractionButtonPressed) {
			if (inventory.GetNewSpell (collider.gameObject.GetComponent<SpellItem> ())) {
				Destroy (collider.gameObject);
			}
		}

		if(Generator_2.CurrentRoom.EnemiesInRoom==0){
		if (collider.gameObject.tag=="DoorR" && Controller.InteractionButtonPressed) {
				Controller.InteractionButtonPressed = false;
				RightDoor ();
		}
		else if (collider.gameObject.tag=="DoorL" && Controller.InteractionButtonPressed) {
				Controller.InteractionButtonPressed = false;
				LeftDoor ();
		}
		else if (collider.gameObject.tag=="DoorU" && Controller.InteractionButtonPressed) {
				Controller.InteractionButtonPressed = false;
				UpDoor ();
		}
		else if (collider.gameObject.tag=="DoorD" && Controller.InteractionButtonPressed) {
				Controller.InteractionButtonPressed = false;
				DownDoor ();
		}
	}
  }


	private void RightDoor(){
		Generator_2.SetRoomRight ();
		ThisTransform.position = Generator_2.CurrentRoom.DoorL.transform.position+new Vector3(0,0);
		Generator_2.CurrentRoom.StartSpawning ();

		AstarPath.active.Scan ();
	}

	private void LeftDoor(){

		Generator_2.SetRoomLeft ();
		ThisTransform.position = Generator_2.CurrentRoom.DoorR.transform.position+new Vector3(0,0);
		Generator_2.CurrentRoom.StartSpawning ();

		AstarPath.active.Scan ();
	}

	private void UpDoor(){

		Generator_2.SetRoomUp ();
		ThisTransform.position = Generator_2.CurrentRoom.DoorD.transform.position+new Vector3(0,0);
		Generator_2.CurrentRoom.StartSpawning ();

		AstarPath.active.Scan ();
	}

	private void DownDoor(){

		Generator_2.SetRoomDown ();
		ThisTransform.position = Generator_2.CurrentRoom.DoorU.transform.position+new Vector3(0,0);
		Generator_2.CurrentRoom.StartSpawning ();

		AstarPath.active.Scan ();
	}
}
