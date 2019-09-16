using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodRefill : MonoBehaviour {

	public Button refillButton;
	public GameObject foodPanel;

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
				// white when empty
				GetComponent<UnityEngine.UI.Image> ().color = Color.white;
				Debug.Log ("Empty Bowl");
			}
		}
	}

	// red when filled
	public void TaskOnClick() {
		Debug.Log ("Clicked Refill Button");
		bowlFilled = true;
		//GetComponent<UnityEngine.UI.Image>().color = Color.red;
		foodPanel.SetActive(false);
		timeLeft = 10.0f;
	}

	public bool isFilled() {
		return bowlFilled;
	}
}
