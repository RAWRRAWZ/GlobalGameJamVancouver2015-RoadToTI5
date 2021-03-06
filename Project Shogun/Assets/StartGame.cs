﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public string keyPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keyPressed)) {
			startGame();
		}
	}

	public void startGame() {
		transform.root.GetComponent<Animator>().enabled = true;
		SoundManager.instance.Play ("Gong");
		GameObject[] introObjects = GameObject.FindGameObjectsWithTag ("Intro");
		foreach (GameObject obj in introObjects) {
			Destroy (obj);
		}
	}
}
