using UnityEngine;
using System.Collections;

public class InvokeRepeat : MonoBehaviour 
{
	public GameObject[] targets;
	
	
	void Start()
	{
		InvokeRepeating("SpawnObject", Random.Range (1, 5), Random.Range (1,5));
	}
	
	void SpawnObject()
	{		// Instantiate a random enemy.
		int targetIndex = Random.Range(0, targets.Length);
		//Instantiate(targets[targetIndex], transform.position, transform.rotation);


		float x = Random.Range(-300.0f, 300.0f);
		float y = Random.Range(-100.0f, 100.0f);
		Instantiate(targets[targetIndex], new Vector3(x, y), Quaternion.identity);
	}
}