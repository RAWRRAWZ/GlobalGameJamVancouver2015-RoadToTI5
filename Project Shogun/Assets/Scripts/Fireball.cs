using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
	{
		// If it hits an enemy...
		if(col.tag == "Enemies")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<EnemyBehaviour>().Hurt();
			SoundManager.instance.Play("FireHit");
			
			// Call the explosion instantiation.
			//OnExplode();
			
			// Destroy the rocket.
			//Destroy (gameObject);
		}
		
		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag == "Player")
		{
			// If the player hit is a Samurai, change his state to Ninja
			col.gameObject.GetComponent<PlayerState>().currentState = PlayerState.state.DEAD;

			//OnExplode();
			SoundManager.instance.Play("FireHit");
			Destroy (gameObject);
		
		}
	}
}
