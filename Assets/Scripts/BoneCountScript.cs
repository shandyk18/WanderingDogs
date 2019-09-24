using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoneCountScript : MonoBehaviour {

    private int boneCount;

    public Text boneText;

	// Use this for initialization
	void Awake () {
        boneCount = 0;
        boneText.text = "Bones: " + boneCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        //if change in bone count
        boneText.text = "Bones: " + boneCount.ToString();
	}
}
