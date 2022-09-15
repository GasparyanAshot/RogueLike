using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator_2 : MonoBehaviour {

	public Room[] RoomPrefabs;

	public Room[] CommonRooms;
	public Room[] ChestRooms;
	public Room[] BossRooms;

	public Room CurrentRoom;

	public PlayerController Player;

	public int SpawnedRoomsCount;

	void Start (){
	}

	public void SetRoomRight(){
		if (SpawnedRoomsCount < 10 && Random.Range (0, 100) < 50) {
			RoomPrefabs = ChestRooms;
		} else {
			RoomPrefabs = CommonRooms;
		}


		int i = Random.Range (0,RoomPrefabs.Length);
		while (RoomPrefabs [i].DoorL == null) {
			i = Random.Range (0,RoomPrefabs.Length);
		}

		Destroy (CurrentRoom.gameObject);
		Room newRoom=Instantiate (RoomPrefabs[i],Vector3.zero,Quaternion.identity);
		newRoom.DoorL.gameObject.tag = "ClosedDoor";
		CurrentRoom = newRoom;

		SpawnedRoomsCount++;
	}

	public void SetRoomLeft(){
		if (SpawnedRoomsCount < 10 && Random.Range (0, 100) < 50) {
			RoomPrefabs = ChestRooms;
		} else {
			RoomPrefabs = CommonRooms;
		}


		int i = Random.Range (0,RoomPrefabs.Length);
		while (RoomPrefabs [i].DoorR == null) {
			i = Random.Range (0,RoomPrefabs.Length);
		}

		Destroy (CurrentRoom.gameObject);
		Room newRoom=Instantiate (RoomPrefabs[i],Vector3.zero,Quaternion.identity);
		newRoom.DoorR.gameObject.tag = "ClosedDoor";
		CurrentRoom = newRoom;

		SpawnedRoomsCount++;
	}

	public void SetRoomUp(){
		if (SpawnedRoomsCount < 10 && Random.Range (0, 100) < 50) {
			RoomPrefabs = ChestRooms;
		} else {
			RoomPrefabs = CommonRooms;
		}


		int i = Random.Range (0,RoomPrefabs.Length);
		while (RoomPrefabs [i].DoorD == null) {
			i = Random.Range (0,RoomPrefabs.Length);
		}

		Destroy (CurrentRoom.gameObject);
		Room newRoom=Instantiate (RoomPrefabs[i],Vector3.zero,Quaternion.identity);
		newRoom.DoorD.gameObject.tag = "ClosedDoor";
		CurrentRoom = newRoom;

		SpawnedRoomsCount++;
	}

	public void SetRoomDown(){
		if (SpawnedRoomsCount < 10 && Random.Range (0, 100) < 50) {
			RoomPrefabs = ChestRooms;
		} else {
			RoomPrefabs = CommonRooms;
		}


		int i = Random.Range (0,RoomPrefabs.Length);
		while (RoomPrefabs [i].DoorU == null) {
			i = Random.Range (0,RoomPrefabs.Length);
		}

		Destroy (CurrentRoom.gameObject);
		Room newRoom=Instantiate (RoomPrefabs[i],Vector3.zero,Quaternion.identity);
		newRoom.DoorU.gameObject.tag = "ClosedDoor";
		CurrentRoom = newRoom;

		SpawnedRoomsCount++;
	}

}
