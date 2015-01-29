using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {public SwordImpactDelay other;


	private float nextUsage;
	private float delay=0.5f;//two seconds delay.
	// Use this for initialization
	void Start () {
		nextUsage = Time.time + delay;
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
			// If it hits an enemy...
			if (col.tag == "Enemies" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut") {
			{if (Time.time > nextUsage)
			{
				nextUsage = Time.time + delay;
					SoundManager.instance.Play ("SliceImpact"); }	}
						Destroy (col.gameObject);
				} else if (col.gameObject.tag == "Player" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut"){
			{if (Time.time > nextUsage)
				{
					nextUsage = Time.time + delay;
					SoundManager.instance.Play ("SliceImpact"); }	}
				if (col.gameObject.GetComponent<PlayerState> ().currentState == PlayerState.modeState.NINJA)	{
				{if (Time.time > nextUsage)
					{
						nextUsage = Time.time + delay;
						SoundManager.instance.Play ("SliceImpact"); }	}
					col.gameObject.GetComponent<PlayerState> ().currentState--;

				}

			}
	}

	void OnTriggerStay2D (Collider2D col) 
	{
		// If it hits an enemy...
		if (col.tag == "Enemies" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut") {
			{if (Time.time > nextUsage)
				{
					nextUsage = Time.time + delay;
					SoundManager.instance.Play ("SliceImpact"); }	}
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "Player" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut"){
			{if (Time.time > nextUsage)
				{
					nextUsage = Time.time + delay;
					SoundManager.instance.Play ("SliceImpact"); }	}
			if (col.gameObject.GetComponent<PlayerState> ().currentState == PlayerState.modeState.NINJA)	{
				{if (Time.time > nextUsage)
					{
						nextUsage = Time.time + delay;
						SoundManager.instance.Play ("SliceImpact"); }	}
				col.gameObject.GetComponent<PlayerState> ().currentState--;
				
			}
			
		}
	}
}