using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		if (transform.parent.GetComponent<SwordAttack> ().attack == true) {
			// If it hits an enemy...
			if (col.tag == "Enemies") {
				// ... find the Enemy script and call the Hurt function.
				//col.gameObject.GetComponent<EnemyBehaviour> ().Hurt ();
				Destroy (col.gameObject);
			} else if (col.gameObject.tag == "Player") {
				// If the player hit is a Samurai, change his state to Ninja
				//TODO: change to only hurt ninja
				if (col.gameObject.GetComponent<PlayerState> ().currentState == PlayerState.state.NINJA) {
					col.gameObject.GetComponent<PlayerState> ().currentState--;
				}

			}

			transform.parent.GetComponent<SwordAttack> ().attack = false;
		}
	}
}