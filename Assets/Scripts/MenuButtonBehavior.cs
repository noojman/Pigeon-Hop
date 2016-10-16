using UnityEngine;
using System.Collections;

public class MenuButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonTexture = null;

	void Update() {
		if (RetryButtonBehavior.end) {
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKey(KeyCode.Escape)) {
					BirdBehavior.life = 2;
					RetryButtonBehavior.end = false;
					ScoreBehavior.show = 2;
					Application.LoadLevel(1);
				}
			}
		}
	}

	void OnGUI() {
		if (RetryButtonBehavior.end) {
			if (Screen.width <= 640 && Screen.height <= 960) {
				if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2 + 7 * Screen.width / 24, Screen.width / 2, Screen.width / 4), buttonTexture)) {
					RetryButtonBehavior.end = false;
					StartButtonBehavior.beginning = true;
					BirdBehavior.life = 2;
					ScoreBehavior.show = 2;
				}
			} else {
				if (GUI.Button(new Rect(Screen.width / 2 - buttonTexture.width / 2, Screen.height / 2 + 4 * buttonTexture.height / 3, buttonTexture.width, buttonTexture.height), buttonTexture)) {
					RetryButtonBehavior.end = false;
					StartButtonBehavior.beginning = true;
					BirdBehavior.life = 2;
					ScoreBehavior.show = 2;
				}
			}
		}
	}
}