﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDog : MonoBehaviour {

	public Button refillButton;

	public GameObject[] dogs;
	public Transform[] spawnPoints;

	public int spawnFreq;
	public float spawnDelay = 15f;

	private float nextTimeToSpawn = 0f;
	private bool hasToy;
	//private List<Integer> dogInYard;
	private System.Random rand;

	// Use this for initialization
	private void Start () {
		//hasToy = refillButton.GetComponent<>();
		//dogInYard = new ArrayList<> ();
		hasToy = true;
		rand = new System.Random ();
	}
	
	// Update is called once per frame
	void Update () {
		nextTimeToSpawn -= Time.deltaTime;
		if (nextTimeToSpawn < 0) {
			nextTimeToSpawn = 15f;
			// if spawn point has a toy
			if (hasToy) { //refillButton.GetComponent<FoodRefill>().isFilled() && 
				// chooses random dog to spawn
				int dogNum = rand.Next(0, 4);
				// if yard does not already contain chosen dog
				//if (!dogInYard.Contains (dogNum)) {
				Spawn(dogs[dogNum]);
				//}
			}
		}
	}

	void Spawn(GameObject dogToSpawn) {
		// randomly chooses one of four spawn points
		int spawnIndex = rand.Next(0, 4);
		Transform spawnPoint = spawnPoints [spawnIndex];
		// instantiates dog
		GameObject newDog = Instantiate (dogToSpawn, spawnPoint.position, spawnPoint.rotation);
		newDog.SetActive (true);
	}
}
