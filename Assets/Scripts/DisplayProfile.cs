using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayProfile : MonoBehaviour {

	public GameObject profilePanel;

	public void ShowProfile() {
		profilePanel.SetActive (true);
	}
}
