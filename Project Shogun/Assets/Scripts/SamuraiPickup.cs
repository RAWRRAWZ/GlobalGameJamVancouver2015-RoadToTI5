using UnityEngine;
using System.Collections;

public class SamuraiPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.

	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.


	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
	}

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
			SoundManager.instance.Play("ArmourUp");

			// Change the player state to samurai
			PlayerState.state currentState = other.GetComponent<PlayerState>().currentState;
			other.GetComponent<PlayerState>().currentState = PlayerState.state.SAMURAI;

			// Destroy the pickup
			Destroy(transform.root.gameObject);
		}
	}
}
