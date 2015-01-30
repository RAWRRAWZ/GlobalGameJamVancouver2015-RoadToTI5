using UnityEngine;
using System.Collections;

public class InvokeRepeat : MonoBehaviour 
{
	public GameObject[] targets;

	private int maxObjects = 1;
	private int numObjects;
	
	void Start()
	{
		numObjects = 0;
		InvokeRepeating("SpawnObject", Random.Range (4, 6), Random.Range (2, 5));
	}
	
	void SpawnObject()
	{
		if (numObjects < maxObjects) {
			// Instantiate a random enemy.	
			int targetIndex = Random.Range (0, targets.Length);
			//Instantiate(targets[targetIndex], transform.position, transform.rotation);
			//Vector3 screenPosition = new Vector3 (0, 0, 0);
			float y = -5f;
			float x = Random.Range(-70.0f, 40.0f);
			int randomSpawn = Random.Range (0,2);
			switch(randomSpawn){
				case 0:
					y = Random.Range(-36f, -5.0f);
					break;
				case 1:
					y = Random.Range(-52.0f, -42.0f);
					break;
				case 2:
					y = Random.Range(-60.0f, -56.5f);
					break;
				default:
					y = -5f;
					break;
			}


			Instantiate(targets[targetIndex], new Vector2(x, y), Quaternion.identity);
			//Vector2 screenPosition = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width-10), Random.Range (0, Screen.height-15), Camera.main.farClipPlane / 2));
			//Instantiate (targets [targetIndex], screenPosition, Quaternion.identity);
		}
	}

	public void incrementObjects() {
		numObjects++;
	}
	public void decrementObjects() {	
		numObjects--;
	}
}