using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float moveSpeed = -10f;		// The speed the enemy moves at.

	private SpriteRenderer ren;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;			// Whether or not the enemy is dead.


	// Use this for initialization
	void Start()
	{
		Destroy (gameObject, 15);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
