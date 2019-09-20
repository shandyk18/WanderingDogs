using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayMainScene : MonoBehaviour {

	public Button escButton;
	public GameObject profilePanel;

	// Use this for initialization
	void Start () {
		Button btn = escButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	public void TaskOnClick() {
		Debug.Log ("Clicked ESC Button");
		profilePanel.SetActive (false);
	}
}
