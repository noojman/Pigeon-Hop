using UnityEngine;
using System.Collections;

public class StartButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonTexture = null;

	public static bool beginning;

	void Start() {
		beginning = true;
	}

	void Update() {
		if (beginning) {
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKey (KeyCode.Escape)) {
					Application.Quit ();
				}
			}
		}
	}

	void OnGUI() {
		if (beginning) {
			if (Screen.width <= 640 && Screen.height <= 960) {
				if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.width / 5), buttonTexture)) {
					beginning = false;
					BirdBehavior.life = 1;
					BirdBehavior.instructions = true;
					BirdBehavior.inGame = true;
					ScoreBehavior.Setup ();
				}
			} else {
				if (GUI.Button(new Rect(Screen.width / 2 - buttonTexture.width / 2, Screen.height / 2 + buttonTexture.height / 4, buttonTexture.width, buttonTexture.height), buttonTexture)) {
					beginning = false;
					BirdBehavior.life = 1;
					BirdBehavior.instructions = true;
					BirdBehavior.inGame = true;
					ScoreBehavior.Setup ();
				}
			}
		}
	}
}