using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharChoose : MonoBehaviour {

	public Menu menu;
	public GameObject[] Chars;
	public GameObject Border;

	public void SetChar(int i){
		menu.Char = i;
		Border.transform.position = Chars [i].transform.position;
	}
}
