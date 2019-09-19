using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayShop : MonoBehaviour {

	public Button shopButton;

	// Use this for initialization
	void Start () {
		Button btn = shopButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void TaskOnClick () {
		Debug.Log ("Shop button clicked!");
		SceneManager.LoadScene ("Shop");
	}
}
