using UnityEngine;
using System.Collections;

public class RetryButtonBehavior : MonoBehaviour {
	
	public Texture2D buttonTexture = null;
	
	public static bool end;
	
	void Start() {
		ScoreBehavior.SaveScore();
		end = false;
	}

	void OnGUI() {
		if (end) {
			if (Screen.width <= 640 && Screen.height <= 960) {
				if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.width / 5), buttonTexture)) {
					BirdBehavior.life = 3;
					ScoreBehavior.points = 0;
					ScoreBehavior.show = 1;
					end = false;
				}
			} else {
				if (GUI.Button(new Rect(Screen.width / 2 - buttonTexture.width / 2, Screen.height / 2 + buttonTexture.height / 4, buttonTexture.width, buttonTexture.height), buttonTexture)) {
					BirdBehavior.life = 3;
					ScoreBehavior.points = 0;
					ScoreBehavior.show = 1;
					end = false;
				}
			}
		}
	}
}