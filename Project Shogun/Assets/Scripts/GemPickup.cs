using UnityEngine;
using System.Collections;

public class GemPickup : MonoBehaviour
{
	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.
	static private int gemThreshold = 3;

	public GameObject weaponObject;
	
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
			SoundManager.instance.Play("GemPickUp");
			// Increase the number of bombs the player has.
			PlayerState state = other.GetComponent<PlayerState>();

			if (++state.numberOfGems >= gemThreshold) {
				state.superMode = true;
				SoundManager.instance.Play("SuperSamurai");
				state.numberOfGems = 0;

				// Enable the ShurikenThrow script the player has.
				other.GetComponent<WeaponThrow>().weaponCount = 1;
				other.GetComponent<WeaponThrow>().weaponSprite = weaponObject.GetComponent<SpriteRenderer>().sprite;
				other.GetComponent<WeaponThrow>().weaponRB = weaponObject.GetComponent<Rigidbody2D>();
			}

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
	}
	
}
