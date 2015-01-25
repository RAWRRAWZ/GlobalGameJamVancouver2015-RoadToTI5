using UnityEngine;
using System.Collections;

public class SpeedUpPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.

	public int powerUpTime;
	
	void Start() 
	{
		Destroy (gameObject, 8);	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// ... play the pickup sound effect.
			SoundManager.instance.Play("Eat");
			// Increase the number of bombs the player has.
			other.GetComponent<PowerUpState>().currentState = PowerUpState.state.FAST_MODE;

			other.GetComponent<PowerUpState>().powerUpTime = powerUpTime;

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
	}

}
