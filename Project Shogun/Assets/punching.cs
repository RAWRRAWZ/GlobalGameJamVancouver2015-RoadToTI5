using UnityEngine;
using System.Collections;

public class punching : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Enemy" && transform.parent.GetComponent<PlayerAttack>().attack == true){
			Instantiate(explosion,transform.position, Quaternion.identity);
		}
	}
}