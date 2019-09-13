using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDog : MonoBehaviour {

	public Button refillButton;
	public FoodRefill refillScript;

	private bool hasToy;
	private SpriteRenderer sr;

	public Sprite dogSprite;
	public Sprite spawnPoint;

	void Awake() {
		sr = GetComponent<SpriteRenderer>() as SpriteRenderer;
	}

	// Use this for initialization
	void Start () {
		refillScript = refillButton.GetComponent<Button>().GetComponent<FoodRefill>();
		hasToy = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (refillScript.isFilled () && hasToy) {
			sr.sprite = dogSprite;
		} else {
			sr.sprite = spawnPoint;
		}
	}
}
