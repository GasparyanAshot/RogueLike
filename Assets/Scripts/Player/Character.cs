using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	
	public float Speed;
	public int HP;
	public int MaxHP;
	public int MP;
	public int MaxMP;
	public int Shields;
	public int ShieldChance;
	public float CDTime;
	public float SpellCDTime;
	public int Damage;
	public Animator anim;
	public Spell spell;
	public SpriteRenderer sprite;

	public PlayerController player;

	void Start () {
		player.Speed = Speed;
		player.HP = HP;
		player.MaxHP = MaxHP;
		player.MP = MP;
		player.MaxMP = MaxMP;
		player.Shields = Shields;
		player.ShieldChance = ShieldChance;
		player.CDTime = CDTime;
		player.SpellCDTime = SpellCDTime;
		player.Damage = Damage;
		player.anim = anim;
		player.spell = spell;
		player.sprite = sprite;


		player.ui.StartUI ();
		Inventory inventory = player.inventory;
		inventory.SpellsInInventory.Add (spell);
	}

}
