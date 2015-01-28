using UnityEngine;
using System.Collections;

public class PunchAttack : MonoBehaviour
{
	public string triggerPunch;
	public bool attack;
	
	private PlayerState playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;					// Reference to the Animator component.
	private float cooldown;
	
	void Awake()
	{
		// Setting up the references.
		anim = transform.GetComponent<Animator> ();
		playerCtrl = transform.parent.GetComponent<PlayerState>();
		attack = false;
		cooldown = 0f;
	}
	
	
	void Update ()
	{
		if (attack == true && cooldown < 0.4f) {
			cooldown += Time.deltaTime;
					SoundManager.instance.Play("Punch");
				
		} else if (cooldown >= 0.4f){
			cooldown = 0f;
			attack = false;
		}
		// If the fire button is pressed...
		if((playerCtrl.currentState == PlayerState.modeState.NINJA) &&(Input.GetButtonDown(triggerPunch) && cooldown == 0f))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("punching");
			attack = true;
			
		}
		
	}
}