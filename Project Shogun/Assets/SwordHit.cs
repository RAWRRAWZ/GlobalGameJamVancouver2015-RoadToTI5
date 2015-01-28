using UnityEngine;
using System.Collections;

public class SwordHit : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
			// If it hits an enemy...
			if (col.tag == "Enemies" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut") {
			SoundManager.instance.Play ("SliceImpact");	
						Destroy (col.gameObject);
				} else if (col.gameObject.tag == "Player" && transform.parent.GetComponent<Animator> ().GetCurrentAnimationClipState (0) [0].clip.name == "SwordCut"){
						SoundManager.instance.Play ("SliceImpact");
				if (col.gameObject.GetComponent<PlayerState> ().currentState == PlayerState.modeState.NINJA)	{
				SoundManager.instance.Play("SliceImpact");
					col.gameObject.GetComponent<PlayerState> ().currentState--;

				}

			}
	}
}