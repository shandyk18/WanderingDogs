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
	private Random rand;

	// Use this for initialization
	private void Start () {
		//hasToy = refillButton.GetComponent<>();
		//dogInYard = new ArrayList<> ();
		hasToy = true;
		rand = new Random ();
	}
	
	// Update is called once per frame
	void Update () {
		nextTimeToSpawn -= Time.deltaTime;
		if (nextTimeToSpawn < 0) {
			nextTimeToSpawn = 15f;
			if (hasToy) { //refillButton.GetComponent<FoodRefill>().isFilled() && 
				int dogNum = 1;//rand.Next(0, 3);
				//if (!dogInYard.Contains (dogNum)) {
				Spawn(dogs[dogNum]);
				//}

			} else {
				// make GO disappear
			}
		}
	}

	void Spawn(GameObject dogToSpawn) {
		int spawnIndex = 1;//rand.Next(0, 5);
		Transform spawnPoint = spawnPoints [spawnIndex];
		GameObject newDog = Instantiate (dogToSpawn, spawnPoint.position, spawnPoint.rotation);
		newDog.SetActive (true);
		//newDog.GetComponent<Transform> ().parent = transform;
	}
}
