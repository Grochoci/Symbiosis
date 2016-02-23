﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int currentHP;
	public int maxHP;
	private bool onFire;
	private int ongoingDamage;
	private int ongoingTimer;

	// Use this for initialization
	void Start () {
		onFire = false;
		currentHP = maxHP;
		ongoingTimer = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (onFire) {
			if (ongoingTimer <= 0) {
				currentHP = currentHP - ongoingDamage;
				ongoingTimer = 60;
			} else {
				ongoingTimer = ongoingTimer - 1;
			}
		}
		if (currentHP <= 0) {
			Die ();
		}
	}

	void Die(){
		Destroy (gameObject);
	}

	public void TakeDamage(int incomingDamage, string damageType){
		currentHP = currentHP - incomingDamage;
		if (damageType == "fire") {
			onFire = true;
			ongoingDamage = 2;
		}
	}
}
