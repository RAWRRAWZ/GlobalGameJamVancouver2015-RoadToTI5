using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public Rigidbody2D weapon;
	public string triggerPunch = "q";
	public float speed = 20f;				// The speed the rocket will fire at.
	public bool attack;
	
	private PlayerMovement playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	private float cooldown;
	
	void Awake()
	{
		// Setting up the references.
		anim = transform.GetComponent<Animator> ();
		attack = false;
		cooldown = 0f;
	}
	
	
	void Update ()
	{
		
		// If the fire button is pressed...
		if(Input.GetKeyDown(triggerPunch))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetBool("punching", true);
			attack = true;
			
		}

	}
	
	void FixedUpdate(){
		if (cooldown < 0.8f && attack == true) {
			cooldown += Time.deltaTime;
		} else if (cooldown >= 0.8f && attack == true){
			cooldown = 0f;
			attack = false;
			anim.SetBool ("punching", false);
		}
	}
}