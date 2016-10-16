using UnityEngine;
using System.Collections;

public class BirdBehavior : MonoBehaviour {

	public Vector3 startingPosition;

	Vector3 up = new Vector3(0, 1, 0);
	Vector3 down = new Vector3(0, -1, 0);

	public float gravitySpeed;
	public float diveSpeed;
	public float bounceSpeed;

	float bounceIndex;

	public static int life;
	/* 0 : dead
	 * 1 : alive
	 * 2 : before spawning
	 * 3 : resetting
	 */

	bool bouncing;
	bool diving;
	bool slideRed;
	bool slideYellow;
	bool ending;

	public Font myFont;
	
	GUIStyle startStyle = null;

	public static bool instructions;
	public static bool inGame;

	public Sprite spriteDive;
	public Sprite spriteFloat;
	public Sprite spriteDead;

	public AudioSource[] sounds;
	public AudioSource audioImpact;
	public AudioSource audioSound;
	public AudioSource audioMusic;
	public static AudioSource audioAmbience;

	// Use this for initialization
	void Start () {
		ending = true;
		startStyle = new GUIStyle ();
		if (Screen.width <= 640 && Screen.height <= 960) {
			startStyle.fontSize = 30;
		} else {
			startStyle.fontSize = 40;
		}
		startStyle.font = myFont;
		startStyle.normal.textColor = Color.yellow;
		sounds = GetComponents<AudioSource> ();
		audioImpact = sounds [0];
		audioSound = sounds [1];
		audioMusic = sounds [2];
		audioAmbience = sounds [3];
		if (PlayerPrefs.GetInt ("audiosetting") == 0) {
			audioAmbience.Play ();
		}
		inGame = false;
		life = 2;
		bouncing = false;
		diving = false;
		slideRed = false;
		slideYellow = false;
		bounceIndex = bounceSpeed;
	}

	// Do Graphics & Input updates here
	void Update() {
		if (life == 1 && bouncing == false) {
			if (Input.GetMouseButtonDown(0)) {
				instructions = false;
				GetComponent<SpriteRenderer>().sprite = spriteDive;
				diving = true;
			}
			if (Input.GetMouseButtonUp (0)) {
				GetComponent<SpriteRenderer>().sprite = spriteFloat;
				diving = false;
			}
		}
	}

	void OnGUI() {
		if (instructions) {
			transform.position = startingPosition;
			if (Screen.width <= 640 && Screen.height <= 960) {
				GUI.Label(new Rect(Screen.width / 2 - 203, Screen.height / 2 - 100, 100, 25), "          Touch to dive - \nhit the red cars to survive!", startStyle);
			} else {
				GUI.Label(new Rect(Screen.width / 2 - 270, Screen.height / 2 - 200, 200, 50), "          Touch to dive - \nhit the red cars to survive!", startStyle);
			}
		}
	}

	// Do physics engine updates here
	void FixedUpdate () {
		if (instructions == false) {
			if (inGame == true) {
				if (audioAmbience.isPlaying == true && AudioButtonBehavior.audioSetting == 0) {
					audioAmbience.Stop ();
				}
				if (MusicButtonBehavior.musicSetting == 0) {
					audioMusic.Play ();
				}
				inGame = false;
			}
			if (life == 1) {
				slideRed = false;
				slideYellow = false;
				if (bouncing == false) {
					if (diving == false) {
						transform.position += down * gravitySpeed * Time.deltaTime;
					} else {
						transform.position += down * diveSpeed * Time.deltaTime;
					}
				} else {
					if (diving == true) {
						diving = false;
						bounceIndex = 20;
					}
					transform.position += up * bounceIndex * Time.deltaTime;
					bounceIndex -= 1;
					if (bounceIndex == 0) {
						bouncing = false;
						bounceIndex = bounceSpeed;
					}
				}
			} else if (life == 0) {
				if (audioMusic.isPlaying) {
					audioMusic.Stop ();
				}
				if (slideRed == true && transform.position.x > -4) {
					slideYellow = false;
					transform.position += RedCarBehavior.speed * Time.deltaTime;
				}
				if (slideYellow == true && transform.position.x > -4) {
					slideRed = false;
					transform.position += YellowCarBehavior.speed * Time.deltaTime;
				}
				if (transform.position.x < -3 && ending == true) {
					RetryButtonBehavior.end = true;
					ScoreBehavior.show = 0;
					ScoreBehavior.SaveScore ();
					ending = false;
				}
			} else if (life == 3 && instructions == false) {
				if (audioAmbience.isPlaying == true) {
					audioAmbience.Stop ();
				}
				ending = true;
				inGame = true;
				bouncing = false;
				diving = false;
				slideRed = false;
				slideYellow = false;
				bounceIndex = bounceSpeed;
				transform.position = startingPosition;
				GetComponent<SpriteRenderer>().sprite = spriteFloat;
				life = 1;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Ground") {
			GetComponent<SpriteRenderer>().sprite = spriteDead;
			if (audioMusic.isPlaying) {
				audioMusic.Stop ();
			}
			if (AudioButtonBehavior.audioSetting == 0) {
				audioAmbience.Play ();
				audioSound.Play();
			}
			ending = true;
			life = 0;
		} else if (collision.gameObject.name == "YellowCar") {
			if (life == 0) {
				slideYellow = true;
			}
		} else if (collision.gameObject.name == "RedCar") {
			if (life == 1) {
				bouncing = true;
				GetComponent<SpriteRenderer>().sprite = spriteFloat;
				if (AudioButtonBehavior.audioSetting == 0) {
					audioImpact.Play ();
				}
				ScoreBehavior.addPoint ();
			} else if (life == 0) {
				slideRed = true;
			}
		}
	}
}