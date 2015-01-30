using UnityEngine;
using System.Collections;

public class LeftSidePlayerEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D col) {
		// If it hits an enemy...
		if (col.tag == "Enemies" || col.tag == "Player") {
			col.transform.position = new Vector3(41.5f, col.transform.position.y, col.transform.position.z);
		}
	}
}
