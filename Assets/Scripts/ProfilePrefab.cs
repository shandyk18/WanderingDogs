using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePrefab : MonoBehaviour {

	private GameObject profileDisplayer;
	private DisplayProfile displayProfile;
    private System.Random rand;

    public Sprite[] dogSprites;
    public SpriteRenderer sr;

    void Start() {
        rand = new System.Random();
        displayProfile = GameObject.Find ("DisplayProfile").GetComponent<DisplayProfile> ();
        dogSprites = new Sprite[4];
        sr.sprite = dogSprites[rand.Next(0, 4)];
    }

	public void OnMouseDown() {
		Debug.Log ("Profile Clicked");
		displayProfile.ShowProfile ();
	}
		
}
