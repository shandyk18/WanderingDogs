using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodRefill : MonoBehaviour {

	public Button refillButton;
	public GameObject foodPanel;

	protected float timeLeft = 10.0f; 
	private bool bowlFilled;

	void Start () {
		Button btn = refillButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		bowlFilled = false;
	}

	// bug comes from hiding panel so Update() not called
	void Update () {
		Debug.Log (bowlFilled);
		if (bowlFilled == true) {
			timeLeft -= Time.deltaTime;
			Debug.Log (timeLeft);
			if (timeLeft < 0) {
				bowlFilled = false;
				Debug.Log ("Empty Bowl");
			}
		}
	}

	// red when filled
	public void TaskOnClick() {
		Debug.Log ("Clicked Refill Button");
		timeLeft = 10.0f;
		bowlFilled = true;
		//GetComponent<UnityEngine.UI.Image>().color = Color.red;
		foodPanel.SetActive(false);
	}

	public bool isFilled() {
		return bowlFilled;
	}
}
