using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDog : MonoBehaviour {

	private float timeRemaining;

	public GameObject thisDog;

	// Use this for initialization
	void Start () {
		System.Random rand = new System.Random ();
		timeRemaining = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining < 0) {
			Destroy (thisDog);
			Debug.Log ("10 Bones Given");
		}
	}
}
