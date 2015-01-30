using UnityEngine;
using System.Collections;

public class RightSidePlayerEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		// If it hits an enemy...
		if (col.tag == "Enemies" || col.tag == "Player") {
			col.transform.position = new Vector3(-74.3f, col.transform.position.y, col.transform.position.z);
		}
	}
}
