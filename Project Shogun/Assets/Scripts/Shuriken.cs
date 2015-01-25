using UnityEngine;
using System.Collections;

public class Shuriken : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3f);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			// ... find the Enemy script and call the Hurt function.
			//col.gameObject.GetComponent<Enemy>().Hurt();
			
			// Call the explosion instantiation.
			//OnExplode();
			
			// Destroy the rocket.
			Destroy (gameObject);
		}

		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag == "Player")
		{
			// If the player hit is a Samurai, change his state to Ninja
			col.gameObject.GetComponent<PlayerState>().currentState--;



			//OnExplode();
			Destroy (gameObject);
		}
	}
}
