using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] Chars;

	void Start () {
		Chars [PlayerPrefs.GetInt ("Char")].SetActive (true);
	}
}
