using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour {

	public GameObject menuPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick() {
		Debug.Log ("Menu Button Clicked!");
		menuPanel.SetActive (true);
	}

}
