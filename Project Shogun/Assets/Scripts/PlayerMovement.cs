﻿using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {
	public int walkspeed = 4;

	public bool jump = false;				// Condition for whether the player should jump.
	public bool facingRight = true;
	public string horizInput;
	public string jumpInput;

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 12f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private float speedTimer = 0;
	private float normalspeed;
	private bool grounded = true;
	private Transform groundCheck;


	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		normalspeed = maxSpeed;
	}
	
	
	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if(Input.GetButtonDown(jumpInput) && grounded)
			jump = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Cache the horizontal input.
		float h = Input.GetAxis (horizInput);

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if (h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce (Vector2.right * h * moveForce);
		
			// If the player's horizontal velocity is greater than the maxSpeed...
		if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
		
			// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip ();
			// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
			Flip ();

		// If the player should jump...
		if (jump) {
			// Add a vertical force to the player.
			rigidbody2D.AddForce (new Vector2 (0f, jumpForce));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
