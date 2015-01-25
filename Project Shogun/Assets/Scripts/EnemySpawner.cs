using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public float spawnTime = 15f;		// The amount of time between each spawn.
	public float spawnDelay = 10f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.

	private int maxEnemies = 10;
	private int numEnemies;

	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
		numEnemies = 0;
		/**
		if (startingRight) {
			foreach (GameObject obj in enemies){
				obj.GetComponent<EnemyBehaviour>().startingRight = true;
			}
		}
		**/
	}


	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
 	 			Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		//foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		//{
			//p.Play();
		//}
	}
}
