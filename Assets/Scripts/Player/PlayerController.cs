using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float dirX=0,dirY=0;
	public int RoomX=5,RoomY=5;
	private bool Fliped=false;
	public Camera cam;
	public bool InteractionButtonPressed;
	public UI ui;

	public Joystick MoveJoystick;
	public Joystick FireJoystick;

	public float Speed;
	public int HP;
	public int MaxHP;
	public int MP;
	public int MaxMP;
	public int Damage;
	public int Shields;
	public int ShieldChance;
	public float CDTime;
	public float SpellCDTime;
	public Animator anim;
	public Spell spell;
	public SpriteRenderer sprite;

	bool isCD=false;



	public Transform ThisTransform;
	public Inventory inventory;
	private int SpellNow; 
	public GameObject FireDirUI;
	public LevelGenerator_2 Generator;

	void Start () {
		ThisTransform = transform;
	}
	

	void FixedUpdate () {
		PC_Controll ();
		Android_Controll();
	}











	void Walk(){
		anim.SetBool ("Walk", true);
	}
	void WalkStop(){
		anim.SetBool ("Walk", false);
	}
	void Bottom(){
		anim.SetBool ("Bottom", true);
	}
	void BottomStop(){
		anim.SetBool ("Bottom", false);
	}
	void Flip(){
		if (sprite.flipX == true)
		{
		sprite.flipX = false;
		Fliped = false;
	}
		else {
			sprite.flipX = true;
			Fliped = true;
		}
	}


	public void Fire(Vector2 Firedirection){
		if (!isCD && MP>=spell.ManaCost) {
			MP -= spell.ManaCost;
			Spell newspell = Instantiate (spell, ThisTransform.position, Quaternion.identity,Generator.CurrentRoom.transform);
			newspell.Direction = Firedirection*inventory.FireDir;
			newspell.DamageUp = inventory.DamageUp;
			newspell.DamageUpPracentage = inventory.DamageUpPracentage;
			newspell.SpeedUp = inventory.SpellSpeedUp;
			newspell.Player = this;
			isCD = true;
			Invoke ("CoolDown", CDTime+spell.CD);
		}
	}

	void CoolDown(){
		isCD = false;
	}












void Android_Controll(){
		if (MoveJoystick.InputVector != Vector2.zero) Walk ();
		else WalkStop ();

		if (FireJoystick.InputVector != Vector2.zero) {
			Vector2 InputVector = FireJoystick.InputVector;
			InputVector = (InputVector.magnitude < 1.0f) ? InputVector.normalized : InputVector;
			if(!FireDirUI.activeSelf) FireDirUI.SetActive (true);
			FireDirUI.transform.right = InputVector;
			Fire (InputVector);
		} else if(FireDirUI.activeSelf){
			FireDirUI.SetActive(false);
		}

		if (MoveJoystick.InputVector.y > 0) Bottom ();
		else if (MoveJoystick.InputVector.y < 0) BottomStop ();

		if (MoveJoystick.InputVector.x < 0 && !Fliped) Flip ();
		else if (MoveJoystick.InputVector.x > 0 &&  Fliped) Flip ();

		if (MoveJoystick.InputVector != Vector2.zero) {
			ThisTransform.Translate (MoveJoystick.InputVector * Speed * Time.deltaTime);
		}
	}


public void Android_Interaction(){
		InteractionButtonPressed = true;
	}
public void Android_Interaction_False(){
		InteractionButtonPressed = false;
	}


public void NextSpell(){
		if (SpellNow < inventory.SpellsInInventory.Count-1) {
			SpellNow++;
		} else
			SpellNow = 0;
		spell=inventory.SpellsInInventory[SpellNow];	
	}

public void PreviousSpell(){
		if (SpellNow > 0) {
			SpellNow--;
		} else
			SpellNow = inventory.SpellsInInventory.Count-1;
		spell=inventory.SpellsInInventory[SpellNow];	
	}



 void PC_Controll(){
		if (Input.GetKey(KeyCode.RightArrow)){
			Fire (Vector2.right);
		}
		else if (Input.GetKey(KeyCode.LeftArrow)){
			Fire (Vector2.left);
		}
		else if (Input.GetKey(KeyCode.UpArrow)){
			Fire (Vector2.up);
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			Fire (Vector2.down);
		}

	if (Input.GetKey (KeyCode.A)) {
		dirX = -1;
		Walk ();
		if (!Fliped ) {
			Flip ();
		}
	}
	if(Input.GetKey (KeyCode.D)) {
		dirX = 1;
		Walk ();
		if (Fliped ) {
			Flip ();
		}
	}
	if (!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
		dirX = 0;
	}
	if(Input.GetKey (KeyCode.W)) {
		dirY = 1;
		Walk ();
		Bottom ();
	}
	if(Input.GetKey (KeyCode.S)) {
		dirY = -1;
		Walk ();
		BottomStop();
	}
	if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.S)) {
		dirY = 0;
	}
	if (dirX == 0 && dirY == 0) WalkStop ();
		if (dirX != 0 || dirY != 0) {
			ThisTransform.Translate (new Vector2 (dirX, dirY) * Speed * Time.deltaTime);
		}

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			NextSpell();
		}
		if(Input.GetKeyDown(KeyCode.LeftControl)){
				PreviousSpell();
			}
				
		if (Input.GetKeyDown (KeyCode.Space)) {
			InteractionButtonPressed = true;
		} 
		if (Input.GetKeyUp (KeyCode.Space)) {
			InteractionButtonPressed = false;
		}
}
}