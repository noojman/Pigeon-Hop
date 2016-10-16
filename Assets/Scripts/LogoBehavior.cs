using UnityEngine;
using System.Collections;

public class LogoBehavior : MonoBehaviour {
	
	public Texture2D logoTexture = null;
	
	void OnGUI() {
		if (StartButtonBehavior.beginning) {
			if (Screen.width <= 640 && Screen.height <= 960) {
				GUI.Label (new Rect(Screen.width / 8 - Screen.width / 32 - Screen.width / 64, Screen.height / 2 - Screen.width / 2, Screen.width, Screen.width / 3), logoTexture);
			} else {
				GUI.Label (new Rect(Screen.width / 2 - logoTexture.width / 2, Screen.height / 2 - 5 * logoTexture.height / 4, logoTexture.width, logoTexture.height), logoTexture);
			}
		}
	}
}