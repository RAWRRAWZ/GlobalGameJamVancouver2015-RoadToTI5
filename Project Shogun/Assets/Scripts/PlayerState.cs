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

	public GameObject ninjaAnimModel;
	public GameObject samuraiAnimModel;
		
	public GameObject superNinjaAnimModel;
	public GameObject superSamuraiAnimModel;
	public GameObject ninjaArm;
	public GameObject samuraiSword;

	public Sprite deadModel;
	public SpriteRenderer ren;

	//public GameObject ninjaObject;

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
			transform.root.GetComponent<PlayerMovement>().maxSpeed = 25;
			ninjaArm.SetActive(true);
			samuraiSword.SetActive(false);
			if (!superMode){
				ren.sprite = ninjaModel;
				//transform.root.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = ninjaObject.GetComponent<SpriteRenderer>().sprite;
				//transform.root.Find("body").gameObject.GetComponent<Animator>().runtimeAnimatorController = ninjaObject.GetComponent<Animator>().runtimeAnimatorController;
			}
			else 
				ren.sprite = superNinjaModel;
			break;
		case state.SAMURAI:
			transform.root.GetComponent<PlayerMovement>().maxSpeed = 18;
			ninjaArm.SetActive(false);
			samuraiSword.SetActive(true);
			if (!superMode)
				ren.sprite = samuraiModel;
			else 
				ren.sprite = superSamuraiModel;
			break;
		case state.DEAD:
			SoundManager.instance.Play("Round");
			Destroy (transform.root.gameObject);
			//guiText.text = gameOverText;
			GameOver();
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

	void GameOver() {
		//GameObject.FindWithTag ("Finish").gameObject.GetComponent<Canvas> ().enabled = true;;
		//Application.LoadLevel(Application.loadedLevel);
	}
}
