using UnityEngine;
using System.Collections;

public class GameStartSound : MonoBehaviour {

	public void StartGong() {
		SoundManager.instance.Play ("Gong");
	}
}
