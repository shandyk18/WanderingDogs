using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDog : MonoBehaviour {

	private float timeRemaining;

	public GameObject thisDog;
    public int bones;

	// Use this for initialization
	void Start () {
		//System.Random rand = new System.Random ();
		timeRemaining = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining < 0) {
			Destroy (thisDog);
            bones = 10;
			Debug.Log ("10 Bones Given");
		}
	}
}
