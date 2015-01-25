using UnityEngine;
using System.Collections;

public class InvokeRepeat : MonoBehaviour 
{
	public GameObject[] targets;

	private int maxObjects = 10;
	private int numObjects;
	
	void Start()
	{
		numObjects = 0;
		InvokeRepeating("SpawnObject", Random.Range (1, 8), Random.Range (1, 8));
	}
	
	void SpawnObject()
	{
		if (numObjects < maxObjects) {
			// Instantiate a random enemy.	
			int targetIndex = Random.Range (0, targets.Length);
			//Instantiate(targets[targetIndex], transform.position, transform.rotation);
			//Vector3 screenPosition = new Vector3 (0, 0, 0);
			Vector3 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), Camera.main.farClipPlane / 2));
			Instantiate (targets [targetIndex], screenPosition, Quaternion.identity);
		}
	}

	public void incrementObjects() {
		numObjects++;
	}
	public void decrementObjects() {	
		numObjects--;
	}
}