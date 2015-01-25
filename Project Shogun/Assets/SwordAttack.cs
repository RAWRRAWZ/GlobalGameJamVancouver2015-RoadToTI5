using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour
{
	public string triggerPunch = "q";
	public bool attack;
	
	private PlayerState playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	private float cooldown;
	
	void Awake()
	{
		// Setting up the references.
		anim = transform.GetComponent<Animator> ();
		playerCtrl = transform.parent.GetComponent<PlayerState> ();
		attack = false;
		cooldown = 0f;
	}
	
	
	void Update ()
	{
		
		// If the fire button is pressed...
		if((playerCtrl.currentState == PlayerState.state.SAMURAI) &&(Input.GetKeyDown(triggerPunch) && cooldown == 0f))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("Attack");
			attack = true;
			
		}
		
	}
	
	void FixedUpdate(){
		if ((cooldown < 0.8f) && (cooldown != 0)) {
			cooldown += Time.deltaTime;
		} else if (cooldown >= 0.8f){
			cooldown = 0f;
			attack = false;
		}
	}
}