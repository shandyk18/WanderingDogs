using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {

	public Button button;
	public GameObject panel;

	void Start() {
		Button btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick() {
		Debug.Log ("Clicked button");
		panel.SetActive (true);
	}

}
