using UnityEngine;
using System.Collections;

public class AntiStick : MonoBehaviour {

	private Transform StickCheck;			// A position marking where to check if the player is grounded.
	private bool stuck = false;			// Whether or not the player is grounded.


	void Awake()
	{
		// Setting up references.
		StickCheck = transform.Find("antiStick");

}


void FixedUpdate()
{
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
				stuck = Physics2D.Linecast (transform.position, StickCheck.position, 1 << LayerMask.NameToLayer ("AntiStick"));  

	// If the jump button is pressed and the player is grounded then the player should jump.
		if  (stuck == true)
		{
			rigidbody2D.AddForce (new Vector2 (-10, -10));
				//rigidbody2D.velocity = -rigidbody2D.velocity;
		}
	}
}




