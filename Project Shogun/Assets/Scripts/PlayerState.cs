using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public enum modeState {
		DEAD,
		NINJA,
		SAMURAI
	};

	public modeState currentState;
	public Sprite ninjaModel;
	public Sprite samuraiModel;

	public Sprite superSamuraiModel;
	public Sprite superNinjaModel;

	public Sprite ninjaAnimArm;
	public Sprite samuraiAnimSword;

	public Sprite superninjaAnimArm;
	public Sprite supersamuraiAnimSword;

	public GameObject ninjaAnimModel;
	public GameObject samuraiAnimModel;
		
	public GameObject superNinjaAnimModel;
	public GameObject superSamuraiAnimModel;
	public GameObject ninjaArm;
	public GameObject samuraiSword;

	public Sprite deadModel;
	public SpriteRenderer ren;

	public enum speedState {
		NORMAL_MODE	,
		FAST_MODE
	};
	
	//public GameObject ninjaObject;

	public bool superMode;

	public int numberOfGems;

	public GameObject gameOverScreen;

	public speedState currentSpeedState;
	public int speedPowerUpTime;

	private int superSpeed = 30;
	private int ninjaSpeed = 20;
	private int samuraiSpeed = 12;


	// Use this for initialization
	void Awake () {
		//ren = transform.Find("testPlayer").GetComponent<SpriteRenderer>();
	}

	void Start () {
		currentState = modeState.SAMURAI;
		numberOfGems = 0;
		superMode = false;
		currentSpeedState = speedState.NORMAL_MODE;
		speedPowerUpTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case modeState.NINJA:
			ninjaArm.SetActive(true);
			samuraiSword.SetActive(false);

			transform.root.GetComponent<PlayerMovement>().maxSpeed = ninjaSpeed;
			if (!superMode){
				ninjaArm.GetComponent<SpriteRenderer>().sprite = ninjaAnimArm;
				ren.sprite = ninjaModel;
				//transform.root.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = ninjaObject.GetComponent<SpriteRenderer>().sprite;
				//transform.root.Find("body").gameObject.GetComponent<Animator>().runtimeAnimatorController = ninjaObject.GetComponent<Animator>().runtimeAnimatorController;
			}
			else {
				ninjaArm.GetComponent<SpriteRenderer>().sprite = superninjaAnimArm;
				ren.sprite = superNinjaModel;
			}
			break;
		case modeState.SAMURAI:
			transform.root.GetComponent<PlayerMovement>().maxSpeed = samuraiSpeed;
			ninjaArm.SetActive(false);
			samuraiSword.SetActive(true);
			if (!superMode){
				samuraiSword.GetComponent<SpriteRenderer>().sprite = samuraiAnimSword;
				ren.sprite = samuraiModel;
			}else { 
				samuraiSword.GetComponent<SpriteRenderer>().sprite = supersamuraiAnimSword;
				ren.sprite = superSamuraiModel;
			}
			break;
		case modeState.DEAD:
			SoundManager.instance.Play("Round");
			Destroy (transform.root.gameObject);
			//guiText.text = gameOverText;
			GameOver();
			break;
		default:
			break;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		switch (currentSpeedState) {
		case speedState.FAST_MODE:
			transform.root.GetComponent<PlayerMovement>().maxSpeed = superSpeed;
			speedPowerUpTime--;
			if (speedPowerUpTime <= 0) {
				currentSpeedState = speedState.NORMAL_MODE;
			}
			break;
		case speedState.NORMAL_MODE:
		default:
			if (currentState == modeState.NINJA) {
				transform.root.GetComponent<PlayerMovement>().maxSpeed = ninjaSpeed;
			} else if (currentState == modeState.SAMURAI) {
				transform.root.GetComponent<PlayerMovement>().maxSpeed = samuraiSpeed;
			}
			break;
		}
	}

	void GameOver() {
		gameOverScreen.SetActive (true);
		//GameObject.FindWithTag ("Finish").gameObject.GetComponent<Canvas> ().enabled = true;;
		//Application.LoadLevel(Application.loadedLevel);
	}
}
