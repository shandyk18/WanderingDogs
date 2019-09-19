using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMenu : MonoBehaviour {

	public Button menuButton;
	public GameObject menuPanel;

	void Start() {
		Button btn = menuButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick() {
		Debug.Log ("Clicked menu button");
		menuPanel.SetActive (true);
	}

}
