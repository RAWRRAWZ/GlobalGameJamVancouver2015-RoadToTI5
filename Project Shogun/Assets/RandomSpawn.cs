using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerPortal : MonoBehaviour {
	
	private GameObject[] gameObjPool;
	private Queue<GameObject> availableGOQueue = new Queue<GameObject>();
	private Camera cam;
	
	// These are used to determin spawning frequency
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 10.0f;
	
	// Spawning offset (relative to the Spawner object)
	public float spawningOffsetTop = 0f;
	public float spawningOffsetBottom = 0f;
	
	void Start(){
		gameObjPool = new GameObject[transform.childCount];
		cam = GameObject.Find("Main Camera").camera;
		int i = 0;
		foreach(Transform childTr in this.transform){
			// Populate gameObjPool by fetching the children list of the spawner
			gameObjPool[i] = childTr.gameObject;
			// Set object position = to parent's position and make it invisible
			resetObject(gameObjPool[i]);
			i++;
		}
		// Then call the spawning method
		Invoke("spawnObject", Random.Range(minSpawnTime, maxSpawnTime));
	}
	
	// This actualy does the job...
	void spawnObject(){
		// First check for objects out of view
		for(int i=0; i < gameObjPool.Length; i++){
			// Convert object position to screen point, so that we can test object position relatively to camera viewport
			Vector3 screenPt = cam.WorldToScreenPoint(gameObjPool[i].transform.position);
			// Left border
			if(gameObjPool[i].activeSelf == true && screenPt.x < 0){
				resetObject(gameObjPool[i]);
			}
		}
		
		// Spawn an object only if available
		if(availableGOQueue.Count > 0){
			GameObject gameObj = availableGOQueue.Dequeue();
			// Set random offset...
			gameObj.transform.Translate(Vector2.up * Random.Range(spawningOffsetTop, spawningOffsetBottom));
			// Activate the object
			gameObj.SetActive(true);
		}
		// Recursively call this method randomly
		Invoke("spawnObject", Random.Range(minSpawnTime, maxSpawnTime));
	}
	
	public void resetObject(GameObject obj){
		// Deactivate object, reset its position and enqueue it for another spawn
		obj.SetActive(false);
		obj.transform.position = this.transform.position;
		availableGOQueue.Enqueue(obj);
	}
	
}