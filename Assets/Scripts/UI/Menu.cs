using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                                  

public class Menu : MonoBehaviour{

	public int Char;

	public int AllowedRuneCount;
	public int RunesChoosen = 0;
	public List<int> ChoosenRunesIndexes=new List<int>();


	public void Play(){
		PlayerPrefs.SetInt ("Char", Char);

		PlayerPrefs.SetInt ("AllowedRuneCount", AllowedRuneCount);
		for(int i=0;i<AllowedRuneCount;i++){
			PlayerPrefs.SetInt ("Rune"+i.ToString(),ChoosenRunesIndexes[i]);
		}

		SceneManager.LoadScene ("1");
	}
		

}
