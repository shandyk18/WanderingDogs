using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePrefab : MonoBehaviour {

	private GameObject profileDisplayer;
	private DisplayProfile displayProfile;

	void Start() {
		displayProfile = GameObject.Find ("DisplayProfile").GetComponent<DisplayProfile> ();
	}

	public void OnMouseDown() {
		Debug.Log ("Profile Clicked");
		displayProfile.ShowProfile ();
	}
		
}
