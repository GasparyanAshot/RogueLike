using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

	void Start () {
		Invoke ("Destroy", 3);
	}
		
	void Destroy () {
		Destroy (gameObject.gameObject);
	}
}
