using UnityEngine;
using System.Collections;

public class WeaponThrow : MonoBehaviour {

	public bool weaponThrown = false;		// Whether or not a shuriken has currently been thrown.
	public int weaponCount = 0;			// How many shuriken the player has.
	public AudioClip throwSound;			// Sound for when the player lays a shuriken.
	public Rigidbody2D weaponRB = null;				// Prefab of the shuriken.
	public SpriteRenderer weaponRenderer;
	public Sprite weaponSprite;

	public string fireButton;
	//public Sprite originalSprite;

	private PlayerMovement playerCtrl;		// Reference to the PlayerControl script.

	void Awake ()
	{
		playerCtrl = transform.root.GetComponent<PlayerMovement>();

	}
	
	
	void Update ()
	{

		// If the shuriken throwing button is pressed, the shuriken hasn't been laid and there's a shuriken to throw...
		if(Input.GetKeyDown (fireButton) && !weaponThrown && weaponCount > 0)
		{
			// Decrement the number of shuriken.
			weaponCount--;
			
			// Set shurikenThrown to true.
			//shurikenThrown = true;
			if 	(weaponRenderer.sprite.name == "fireball" ){
				SoundManager.instance.Play("FireThrow");
			} else if (weaponRenderer.sprite.name == "shuriken" ){
				SoundManager.instance.Play("ShurikenThrow");
			}
			// Instantiate the shuriken prefab.
			//Instantiate(swan, transform.position, transform.rotation);
			if (playerCtrl.facingRight) { 
				Rigidbody2D weaponInstance = Instantiate(weaponRB, weaponRenderer.transform.position + new Vector3(4.5f, 0, 0), Quaternion.Euler(new Vector3(0,180,0))) as Rigidbody2D;
				weaponInstance.velocity = new Vector2(30f, 0);
			} else { 
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D weaponInstance = Instantiate(weaponRB, weaponRenderer.transform.position + new Vector3(-4.5f, 0, 0), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				weaponInstance.velocity = new Vector2(-30f, 0);
			}
			transform.root.GetComponent<PlayerState>().superMode = false;

		}
		
		// The shuriken weapon should show itself if there are shurikens left to throw
		if (weaponCount > 0) {
			weaponRenderer.sprite = weaponSprite;
		} else {
			weaponRenderer.sprite = null;
		}

	}
}
