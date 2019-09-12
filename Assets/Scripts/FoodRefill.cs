using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodRefill : MonoBehaviour {

	public Button refillButton;

	protected float timeLeft = 10.0f; 
	protected bool bowlFilled;

	void Start () {
		Button btn = refillButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		bowlFilled = false;
	}

	void Update() {
		if (bowlFilled == true) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				bowlFilled = false;
				Debug.Log ("Empty Bowl");
			}
		}
	}

	public void TaskOnClick() {
		Debug.Log ("Clicked Refill Button");
		bowlFilled = true;
		timeLeft = 10.0f;
	}
}
