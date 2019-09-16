using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour {

	public GameObject menuPanel;

	public void TaskOnClick() {
		Debug.Log ("Menu Button Clicked!");
		menuPanel.SetActive (true);
	}

}
