using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	public GameObject[] PassiveItems;
	public GameObject[] Spells;
	public bool IsOpen=false;
	private Transform ThisTransfrom;
	public SpriteRenderer spriteRenderer;
	public Sprite OpenedSprite;


	public void Open(Room room){
		ThisTransfrom = transform;
		IsOpen = true;
		spriteRenderer.sprite = OpenedSprite;
		if (Random.Range (0, 100) <= 75) {
			DropPassiveItem (room);
		} else
			DropSpell (room);
	}

	private void DropPassiveItem(Room room){
		Instantiate (PassiveItems[Random.Range(0,PassiveItems.Length)],new Vector2 (ThisTransfrom.position.x,ThisTransfrom.position.y-1),Quaternion.identity,room.transform);
	}

	private void DropSpell(Room room){
		Instantiate (Spells[Random.Range(0,Spells.Length)],new Vector2 (ThisTransfrom.position.x,ThisTransfrom.position.y-1),Quaternion.identity,room.transform);
	}
}
