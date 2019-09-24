using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayMainScene : MonoBehaviour {

	public Button escButton;
	public GameObject panel;

	// Use this for initialization
	void Start () {
		Button btn = escButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	public void TaskOnClick() {
		Debug.Log ("Clicked ESC Button");
		panel.SetActive (false);
	}
}
