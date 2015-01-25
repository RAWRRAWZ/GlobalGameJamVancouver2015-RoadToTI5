using UnityEngine;
using System.Collections;

public class GemCounter : MonoBehaviour {

	public int gemNumber;

	public PlayerState currentState; 
	private SpriteRenderer ren;

	void Awake() {
//		currentState = transform.GetComponent<PlayerState> ();
		ren = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (currentState.numberOfGems == gemNumber) {
			ren.enabled = true;
		} else if (currentState.numberOfGems == 0) {
			ren.enabled = false;
		}
	}
}
