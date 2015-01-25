using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public enum state {
		SAMURAI,
		NINJA,
		SUPER_SAMURAI,
		SUPER_NINJA,
		DEAD
	};

	public state currentState;
	public Sprite ninjaModel;
	public Sprite samuraiModel;
	public Sprite deadModel;
	public SpriteRenderer ren;

	public int numberOfGems;
	public int superTime;

	// Use this for initialization
	void Awake () {
		//ren = transform.Find("testPlayer").GetComponent<SpriteRenderer>();
	}

	void Start () {
		numberOfGems = 0;
		superTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case state.NINJA:
		case state.SUPER_NINJA:
			ren.sprite = ninjaModel;
			break;
		case state.SAMURAI:
		case state.SUPER_SAMURAI:
			ren.sprite = samuraiModel;
			break;
		case state.DEAD:
			Destroy (transform.root.gameObject);
			break;
		default:
			break;
		}
	}

	void FixedUpdate() {
		switch (currentState) {
		case state.SUPER_NINJA:
			superTime--;
			if (superTime <= 0) {
				currentState = state.NINJA;
			}
			break;
		case state.SUPER_SAMURAI:
			superTime--;
			if (superTime <= 0) {
				currentState = state.SAMURAI;
			}
			break;
		default:
			break;
		}
	}
}
