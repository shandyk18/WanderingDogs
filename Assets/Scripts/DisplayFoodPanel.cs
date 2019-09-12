using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFoodPanel : MonoBehaviour {

	public GameObject panel;

	void start() {
		//Panel pnl = foodPanel.GetComponent<Panel>();
	}

	void OnMouseDown() {
		Debug.Log ("Food bowl clicked");
		panel.SetActive (true);
	}
}
