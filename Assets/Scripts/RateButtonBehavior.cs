using UnityEngine;
using System.Collections;

public class RateButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonTexture = null;
	
	void OnGUI() {
		if (StartButtonBehavior.beginning) {
			if (Screen.width <= 640 && Screen.height <= 960) {
				if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 2 + Screen.width / 3, Screen.width / 2, Screen.width / 5), buttonTexture)) {
					Application.OpenURL ("market://details?id=com.Noojman.PigeonHop");
				}
			} else {
				if (GUI.Button(new Rect(Screen.width / 2 - buttonTexture.width / 2, Screen.height / 2 + 7 * buttonTexture.height / 4, buttonTexture.width, buttonTexture.height), buttonTexture)) {
					Application.OpenURL ("market://details?id=com.Noojman.PigeonHop");
				}
			}
		}
	}
}