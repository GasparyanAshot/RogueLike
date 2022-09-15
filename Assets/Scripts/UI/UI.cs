using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text FPSText;
	float FPS;

	public PlayerController Player;

	public Text HP;
	public Text MP;
	public Text Sheilds;

	public void StartUI(){
		fps ();
		HP.text = Player.HP.ToString () + "/" + Player.MaxHP.ToString ();
		MP.text = Player.MP.ToString () + "/" + Player.MaxMP.ToString ();
		Sheilds.text = Player.Shields.ToString ();
	}

	void Update(){
		HP.text = Player.HP.ToString () + "/" + Player.MaxHP.ToString ();
		MP.text = Player.MP.ToString () + "/" + Player.MaxMP.ToString ();
		Sheilds.text = Player.Shields.ToString ();
	}





	void fps(){
		float current = 0;
		current = (int)(1f / Time.unscaledDeltaTime);
		FPS = (int)current;
		FPSText.text = FPS.ToString ();
		Invoke("fps",1);
	}
}
