using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public enum state {
		DEAD,
		NINJA,
		SAMURAI
	};

	public state currentState;
	public Sprite ninjaModel;
	public Sprite samuraiModel;

	public Sprite superSamuraiModel;
	public Sprite superNinjaModel;

	public Sprite deadModel;
	public SpriteRenderer ren;

	public bool superMode;

	public int numberOfGems;
	public int superTime;

	public string gameOverText;

	// Use this for initialization
	void Awake () {
		//ren = transform.Find("testPlayer").GetComponent<SpriteRenderer>();
	}

	void Start () {
		currentState = state.SAMURAI;
		numberOfGems = 0;
		superTime = 0;
		superMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case state.NINJA:
			if (!superMode)
				ren.sprite = ninjaModel;
			else 
				ren.sprite = superNinjaModel;
			break;
		case state.SAMURAI:
			if (!superMode)
				ren.sprite = samuraiModel;
			else 
				ren.sprite = superSamuraiModel;
			break;
		case state.DEAD:
			Destroy (transform.root.gameObject);
			//guiText.text = gameOverText;
			break;
		default:
			break;
		}
	}

	void FixedUpdate() {
		if (superMode) {
			superTime--;
			if (superTime <= 0) {
				superMode = false;
			}
		}
	}
}
