using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public PlayerController playercontroller;

	public static int PassiveItemsCount=20;
	bool[] PassiveItems=new bool[PassiveItemsCount];

	public static int SpellsCount=20;
	bool[] Spells=new bool[SpellsCount];
	public List<Spell> SpellsInInventory=new List<Spell>();

	public int DamageUp;
	public int DamageUpPracentage;
	public int SpellSpeedUp;
	public int FireDir=1;

	void Start(){
		for(int i=0;i<PlayerPrefs.GetInt("AllowedRuneCount");i++){
			Invoke ("Rune_"+PlayerPrefs.GetInt("Rune"+i.ToString()).ToString(),0);
		}
	}


	public bool GetNewItem(PassiveItem NewItem){
		if (!PassiveItems [NewItem.ItemId]) {
			PassiveItems [NewItem.ItemId] = true;
			Invoke("PassiveItem_"+NewItem.ItemId.ToString(),0);
			return true;
		}
		return false;
	}

	public bool GetNewSpell(SpellItem NewSpell){
		if (!Spells [NewSpell.ItemId]) {
			Spells [NewSpell.ItemId] = true;
			SpellsInInventory.Add (NewSpell.spell);
			return true;
		}
		return false;
	}

	// Passive items voids

	private void PassiveItem_0(){
		DamageUp+=5;
		FireDir = -1;
	}


	// Rune voids

	private void Rune_0(){
		DamageUp += 2;
	}

	private void Rune_1(){
		playercontroller.MaxHP += 2;
		playercontroller.HP +=2;
	}

	private void Rune_2(){
		playercontroller.Shields+=3;
	}

	private void Rune_3(){
		playercontroller.Speed += 3;
	}
}
