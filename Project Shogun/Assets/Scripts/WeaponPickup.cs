using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.

	//public Rigidbody2D weaponRB;

	public GameObject weaponObject;

	//public Sprite weaponSprite;

	void Awake()
	{

	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);

			// Enable the ShurikenThrow script the player has.
			other.GetComponent<WeaponThrow>().weaponCount = 1;

			// Set the sprite to be the current object sprite
			other.GetComponent<WeaponThrow>().weaponSprite = weaponObject.GetComponent<SpriteRenderer>().sprite;

			other.GetComponent<WeaponThrow>().weaponRB = weaponObject.GetComponent<Rigidbody2D>();

			// Destroy the shuriken.
			Destroy(transform.root.gameObject);
		}
	}
}
