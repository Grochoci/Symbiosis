﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour {

	public GameObject enemy1;
	public GameObject enemy2;

	public List<GameObject> spawnpoints;
	public List<GameObject> enemies;
	public int players = 0;
	public static bool playersTogether = false;

	private bool hasTriggered = false;
	public bool roomCleared = false;

	public int switchesActive = 0;

	private CameraController cameraController;

	// Use this for initialization
	void Start () {

		//Add spawnPoints in the room to the array
		foreach (Transform child in transform) {
			if (child.tag == "EnemySpawn") {
				spawnpoints.Add (child.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		//Check if player has enetered room and count enemies
		if (transform.name == "Room11") {
			if (!hasTriggered && switchesActive == 2) {
				hasTriggered = true;
				SpawnEnemies();
			} else if (hasTriggered && !roomCleared) {
				if (CountEnemies() == 0) {
					roomCleared = true;
				}
			}
		} else {
			if (hasTriggered == true) {
				if (roomCleared == false) {
					if (CountEnemies() == 0) {
						roomCleared = true;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {

		//If player enters room, spawn enemies and lock doors
		if (other.tag == "Player") {
			players += 1;

			if (players == 2 && playersTogether == false) {
				playersTogether = true;
				cameraController = GameObject.Find ("CameraP1").GetComponent<CameraController> ();
				cameraController.MergeCamera ();
			}

			if (hasTriggered == false && transform.name != "Room11") {
				hasTriggered = true;
				SpawnEnemies();
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			players -= 1;
		}
	}

	void SpawnEnemies() {
		foreach (GameObject spawnpoint in spawnpoints) {
			char enemyType = spawnpoint.name[5];
			GameObject enemyChild;
			if (enemyType == '1') {
				enemyChild = Instantiate (enemy1, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
			} else {
				enemyChild = Instantiate (enemy2, spawnpoint.transform.position, spawnpoint.transform.rotation) as GameObject;
			}
			enemyChild.transform.parent = transform;
		}
	}

	//Add enemies in the current room to the enemies List
	int CountEnemies() {
		int total = 0;
		enemies.Clear();
		foreach (Transform child in transform) {
			if (child.tag == "Enemy") {
				total++;
			}
		}
		return total;
	}

	public bool getPlayersTogether() {
		return playersTogether;
	}
}
