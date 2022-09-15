using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RuneChoose : MonoBehaviour {

	public Menu menu;
	public  bool Choosen=false;
	public GameObject Border;
	public int RuneID;

	public void ChooseRune(){
		if (Choosen) {
			menu.ChoosenRunesIndexes.RemoveAll (GetRunesIndex);
			menu.RunesChoosen--;
			Choosen = false;
		} else if(menu.RunesChoosen<menu.AllowedRuneCount) {
			menu.RunesChoosen++;
			menu.ChoosenRunesIndexes.Add (RuneID);
			Choosen = true;
		}
		
		Border.SetActive (Choosen);
	}

	private bool GetRunesIndex(int i){
		if (i == RuneID) {
			return true;
		}
		return false;
	}
}
