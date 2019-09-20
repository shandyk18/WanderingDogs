using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTimer : MonoBehaviour {

	private float timeLeft;
	private bool bowlFilled;

	public Button refillButton;
	private FoodRefill refillScript;

	// Use this for initialization
	void Start () {
		timeLeft = 0f;
		refillScript = refillButton.GetComponent<FoodRefill> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (refillScript.bowlFilled) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				refillScript.bowlFilled = false;
				Debug.Log ("Empty Bowl");
			}
		}
	}

	public void TimeRestart() {
		timeLeft = 60f;
	}
}
