﻿using UnityEngine;
using System.Collections;

public class LevelData : MonoBehaviour {

	public static LevelData Instance;

	public static bool randomLevel = true;
	public static int levelSeed = -2001603228;
	public static int levelSize = 5;
	public static int levelDifficulty = 8;


	void Awake () {
		Instance = this;
	}

	public static void SetLevelSeed(int newSeed) {
		levelSeed = newSeed;
	}

	public static void GenerateRandomSeed() {
		levelSeed = (int)System.DateTime.Now.Ticks;
	}

	public static void SetLevelSize(int size) {
		size = Mathf.Min(size, 10);
		size = Mathf.Max(size, 3);
		levelSize = size;
	}

	public static void SetDifficulty(int difficulty) {
		levelDifficulty = difficulty;
	}
}
