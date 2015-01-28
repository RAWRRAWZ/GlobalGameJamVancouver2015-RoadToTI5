using UnityEngine;
using System.Collections;

public class RiceCounter : MonoBehaviour {

	public PlayerState ps;
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
		if (ps.currentSpeedState == PlayerState.speedState.FAST_MODE) {
			ren.enabled = true;
		} else {
			ren.enabled = false;
		}
	}
}
