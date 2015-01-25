using UnityEngine;
using System.Collections;

public class GemPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.

	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.
	private int superTime = 500;
	static private int gemThreshold = 3;

	void Awake()
	{	
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);

			// Increase the number of bombs the player has.
			PlayerState state = other.GetComponent<PlayerState>();

			if (++state.numberOfGems >= gemThreshold) {
				state.superMode = true;
				state.superTime = superTime;
				state.numberOfGems = 0;
			}

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
	}
}
