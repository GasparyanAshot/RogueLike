using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject Player;
	private Transform ThisTransform;

	void Start () {
		ThisTransform = transform;
	}
	

	void Update () {
		ThisTransform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,ThisTransform.position.z);
	}
}
