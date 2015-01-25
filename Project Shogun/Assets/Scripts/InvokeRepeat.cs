using UnityEngine;
using System.Collections;

public class InvokeRepeat : MonoBehaviour 
{
	public GameObject[] targets;
	
	void Start()
	{
		InvokeRepeating("SpawnObject", Random.Range (1, 8), Random.Range (1, 8));
	}
	
	void SpawnObject()
	{		// Instantiate a random enemy.
		int targetIndex = Random.Range(0, targets.Length);
		//Instantiate(targets[targetIndex], transform.position, transform.rotation);
		//Vector3 screenPosition = new Vector3 (0, 0, 0);
		Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
		Instantiate(targets[targetIndex], screenPosition, Quaternion.identity);
	}
}