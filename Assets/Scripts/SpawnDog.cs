using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDog : MonoBehaviour {

	public Button refillButton;
	private FoodRefill refillScript;

	public GameObject[] dogs;
	public Transform[] spawnPoints;

	public int spawnFreq;
	public float spawnDelay = 10f;

    public Text boneText;

    private List<GameObject> dogInYard;
    private float nextTimeToSpawn = 0f;
	private bool hasToy;
    private int boneCount;
	private System.Random rand;

    void Awake() {
        boneCount = 0;
        boneText.text = "Bones: " + boneCount.ToString();
    }

	// Use this for initialization
	private void Start () {
		// gets script that contains bowl bool
		refillScript = refillButton.GetComponent<FoodRefill> ();
        dogInYard = new List<GameObject>();
		hasToy = true;
		rand = new System.Random ();
	}
	
	// Update is called once per frame
	void Update () {
		nextTimeToSpawn -= Time.deltaTime;
		if (nextTimeToSpawn < 0) {
			nextTimeToSpawn = 10f;
			// if spawn point has a toy and bowl is filled
			if (hasToy && refillScript.bowlFilled) {
				// chooses random dog to spawn
				int dogNum = rand.Next(0, 4);
				// if yard does not already contain chosen dog
				//if (!dogInYard.Contains (dogNum)) {
				dogInYard.Add(Spawn(dogs[dogNum]));
				//}
			}
		}
        // TODO: more efficient way to do this?
        if (dogInYard.Contains(null)) {
            //something wrong with this line?
            dogInYard.Remove(null);
            boneCount += 10;
            boneText.text = "Bones: " + boneCount.ToString();
            Debug.Log(dogInYard.Capacity);
        }
        /*foreach (GameObject dog in dogInYard) {
            if(dog == null) {
                dogInYard.Remove(dog);
                boneText.text = "Bones: " + boneCount.ToString();
            }
        }*/
	}

	GameObject Spawn(GameObject dogToSpawn) {
		// randomly chooses one of four spawn points
		int spawnIndex = rand.Next(0, 4);
		Transform spawnPoint = spawnPoints [spawnIndex];
		// instantiates dog
		GameObject newDog = Instantiate (dogToSpawn, spawnPoint.position, spawnPoint.rotation);
		newDog.SetActive (true);
        return newDog;
	}
}
