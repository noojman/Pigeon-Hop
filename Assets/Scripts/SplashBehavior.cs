using UnityEngine;
using System.Collections;

public class SplashBehavior : MonoBehaviour {

	public Texture2D logoTexture = null;
	public Texture2D splashTexture = null;

	public float myTimer;

	void Update () {	
		if (myTimer > 0) {
			myTimer -= Time.deltaTime;
		}
		if (myTimer <= 0) {
			Application.LoadLevel(1);
		}
	}

	void OnGUI() {
		if (Screen.width <= 640 && Screen.height <= 960) {
			GUI.Label (new Rect(Screen.width / 8 - Screen.width / 32 - Screen.width / 64, Screen.height / 2 - Screen.width / 2, Screen.width, Screen.width / 3), logoTexture);
			GUI.Label (new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.width / 2), splashTexture);
		} else {
			GUI.Label (new Rect(Screen.width / 2 - logoTexture.width / 2, Screen.height / 2 - 5 * logoTexture.height / 4, logoTexture.width, logoTexture.height), logoTexture);
			GUI.Label (new Rect(Screen.width / 2 - splashTexture.width / 2, Screen.height / 2, splashTexture.width, splashTexture.height), splashTexture);
		}
	}
}