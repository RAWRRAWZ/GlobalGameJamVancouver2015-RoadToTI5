﻿using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			restartGame();
		}
	}
	
	public void restartGame() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
