using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodRefill : MonoBehaviour {

	public Button refillButton;
	public GameObject foodPanel;
	public GameObject foodBowl;
	public bool bowlFilled;

	private FoodTimer timerScript;

	void Start () {
		Button btn = refillButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		timerScript = foodBowl.GetComponent<FoodTimer> ();
		bowlFilled = false;
	}

	void TaskOnClick() {
		Debug.Log ("Bowl refilled");
		bowlFilled = true;
		timerScript.TimeRestart();
		foodPanel.SetActive(false);
	}
}
